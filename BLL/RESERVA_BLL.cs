using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RESERVA_BLL
    {
        private MP_RESERVA _mpReserva = new MP_RESERVA();
        private MP_PAGO _mpPago = new MP_PAGO();
        private MP_PAQUETE _mpPaquete = new MP_PAQUETE();
        private BITACORA_BLL _bitacora = new BITACORA_BLL();

        public List<BE.RESERVA> ListarReservasDeUsuario(int idUsuario)
            => _mpReserva.ListarPorUsuario(idUsuario);

        public List<BE.RESERVA> ListarTodasLasReservas()
            => _mpReserva.Listar();

        public int SolicitarReserva(int idUsuario, int idPaquete, int cantPersonas)
        {
            var paquetes = _mpPaquete.Listar();
            var paquete = paquetes.Find(p => p.IdPaquete == idPaquete);

            if (paquete == null)
                throw new Exception("El paquete no existe.");
            if (cantPersonas <= 0)
                throw new Exception("La cantidad de personas debe ser mayor a cero.");
            if (paquete.CuposDisponibles < cantPersonas)
                throw new Exception($"No hay suficientes cupos. Disponibles: {paquete.CuposDisponibles}.");

            decimal importeTotal = paquete.Precio * cantPersonas;

            var reserva = new BE.RESERVA
            {
                IdUsuario = idUsuario,
                IdPaquete = idPaquete,
                CantPersonas = cantPersonas,
                ImporteTotal = importeTotal
            };
            int idReserva = _mpReserva.Insertar(reserva);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Reservas", $"Se solicitó reserva para '{paquete.Destino}', {cantPersonas} persona(s), importe ${importeTotal}", "INFO");

            return idReserva;
        }

        public void RegistrarPago(int idReserva, decimal monto, string metodoPago)
        {
            if (monto <= 0)
                throw new Exception("El monto debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(metodoPago))
                throw new Exception("El método de pago no puede estar vacío.");

            var pago = new BE.PAGO
            {
                IdReserva = idReserva,
                Monto = monto,
                MetodoPago = metodoPago
            };
            _mpPago.Insertar(pago);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Reservas", $"Se registró pago de ${monto} via {metodoPago} para reserva {idReserva}", "INFO");
        }

        public void ConfirmarReserva(int idReserva)
        {
            var pago = _mpPago.ObtenerPorReserva(idReserva);
            if (pago == null)
                throw new Exception("No se puede confirmar sin un pago registrado.");

            _mpPago.Confirmar(pago.IdPago);
            _mpReserva.Confirmar(idReserva);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Reservas", $"Se confirmó la reserva {idReserva}", "INFO");
        }

        public void CancelarReserva(int idReserva)
        {
            _mpReserva.Cancelar(idReserva);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Reservas", $"Se canceló la reserva {idReserva}", "WARNING");
        }

        public BE.PAGO ObtenerPago(int idReserva)
            => _mpPago.ObtenerPorReserva(idReserva);
    }
}