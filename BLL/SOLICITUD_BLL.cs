using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SOLICITUD_BLL
    {
        private MP_SOLICITUD _mapper = new MP_SOLICITUD();
        private MP_RESERVA _mpReserva = new MP_RESERVA();
        private MP_PAGO _mpPago = new MP_PAGO();
        private BITACORA_BLL _bitacora = new BITACORA_BLL();

        public List<BE.SOLICITUD> ListarSolicitudesDeUsuario(int idUsuario)
            => _mapper.ListarPorUsuario(idUsuario);

        public List<BE.SOLICITUD> ListarTodasLasSolicitudes()
            => _mapper.Listar();

        public BE.SOLICITUD ObtenerSolicitud(int idSolicitud)
            => _mapper.ObtenerPorId(idSolicitud);


        public int RegistrarSolicitud(BE.SOLICITUD solicitud)
        {
            if (string.IsNullOrWhiteSpace(solicitud.Descripcion))
                throw new Exception("La descripción no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(solicitud.Tipo))
                throw new Exception("Debe seleccionar un tipo de solicitud.");
            if (solicitud.Tipo == "Cancelación de reserva" && !solicitud.IdReserva.HasValue)
                throw new Exception("Debe asociar una reserva para solicitar su cancelación.");

            int idSolicitud = _mapper.Insertar(solicitud);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Solicitudes", $"Se registró solicitud de tipo '{solicitud.Tipo}'", "INFO");

            return idSolicitud;
        }

        public void AsignarEmpleado(int idSolicitud, int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new Exception("Debe seleccionar un empleado válido.");

            _mapper.AsignarEmpleado(idSolicitud, idEmpleado);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Solicitudes", $"Se asignó empleado a solicitud {idSolicitud}", "INFO");
        }

        public void ResponderSolicitud(int idSolicitud, string respuesta)
        {
            if (string.IsNullOrWhiteSpace(respuesta))
                throw new Exception("La respuesta no puede estar vacía.");

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;

            _mapper.AsignarEmpleado(idSolicitud, usuario.Id);

            _mapper.Responder(idSolicitud, respuesta);

            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Solicitudes", $"Se respondió la solicitud {idSolicitud}", "INFO");
        }

        public void CerrarSolicitud(int idSolicitud, bool devolucionPago)
        {
            var solicitud = _mapper.ObtenerPorId(idSolicitud);
            if (solicitud == null)
                throw new Exception("La solicitud no existe.");
            if (solicitud.Estado != "Resuelta")
                throw new Exception("Solo se pueden cerrar solicitudes en estado Resuelta.");

            if (solicitud.Tipo == "Cancelación de reserva" && solicitud.IdReserva.HasValue)
            {
                var pago = _mpPago.ObtenerPorReserva(solicitud.IdReserva.Value);

                _mpReserva.Cancelar(solicitud.IdReserva.Value);

                var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
                _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                    "Solicitudes",
                    $"Se canceló la reserva {solicitud.IdReserva.Value} por solicitud {idSolicitud}" +
                    (devolucionPago && pago != null ? " con devolución de pago" : ""), "WARNING");
            }

            _mapper.Cerrar(idSolicitud, devolucionPago);

            var usr = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usr.Id, usr.Username,
                "Solicitudes", $"Se cerró la solicitud {idSolicitud}", "INFO");
        }

        public void CancelarSolicitud(int idSolicitud)
        {
            var solicitud = _mapper.ObtenerPorId(idSolicitud);
            if (solicitud == null)
                throw new Exception("La solicitud no existe.");
            if (solicitud.Estado != "Pendiente" && solicitud.Estado != "En revisión")
                throw new Exception("Solo se pueden cancelar solicitudes en estado Pendiente o En revisión.");
            if (solicitud.Tipo == "Cancelación de reserva")
                throw new Exception("Las solicitudes de cancelación de reserva deben responderse y cerrarse para procesar la baja de la reserva.");

            _mapper.CancelarSolicitud(idSolicitud);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Solicitudes", $"Se canceló la solicitud {idSolicitud}", "WARNING");
        }

    }
}