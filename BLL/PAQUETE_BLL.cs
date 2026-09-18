using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PAQUETE_BLL
    {
        private MP_PAQUETE _mapper = new MP_PAQUETE();
        private MP_SERVICIO _mpServicio = new MP_SERVICIO();
        private BITACORA_BLL _bitacora = new BITACORA_BLL();

        public List<BE.PAQUETE> ListarPaquetes()
            => _mapper.Listar();

        public List<BE.SERVICIO> ListarServicios()
            => _mpServicio.Listar();

        public List<BE.SERVICIO> ListarServiciosDePaquete(int idPaquete)
            => _mpServicio.ListarServiciosDePaquete(idPaquete);

        public int InsertarPaquete(BE.PAQUETE paquete)
        {
            if (string.IsNullOrWhiteSpace(paquete.Destino))
                throw new Exception("El destino no puede estar vacío.");
            if (paquete.Precio <= 0)
                throw new Exception("El precio debe ser mayor a cero.");
            if (paquete.CuposTotal <= 0)
                throw new Exception("Los cupos deben ser mayor a cero.");
            if (paquete.FechaRegreso <= paquete.FechaSalida)
                throw new Exception("La fecha de regreso debe ser posterior a la de salida.");

            int idPaquete = _mapper.Insertar(paquete);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Paquetes", $"Se dio de alta el paquete: {paquete.Destino}", "INFO");

            return idPaquete;
        }

        public void AgregarServicioAPaquete(int idPaquete, int idServicio)
            => _mpServicio.AgregarServicioAPaquete(idPaquete, idServicio);

        public void QuitarServicioDePaquete(int idPaquete, int idServicio)
            => _mpServicio.QuitarServicioDePaquete(idPaquete, idServicio);

        public void ModificarPaquete(BE.PAQUETE paquete)
        {
            if (string.IsNullOrWhiteSpace(paquete.Destino))
                throw new Exception("El destino no puede estar vacío.");
            if (paquete.Precio <= 0)
                throw new Exception("El precio debe ser mayor a cero.");
            if (paquete.FechaRegreso <= paquete.FechaSalida)
                throw new Exception("La fecha de regreso debe ser posterior a la de salida.");

            _mapper.Modificar(paquete);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Paquetes", $"Se modificó el paquete: {paquete.Destino}", "WARNING");
        }

        public void EliminarPaquete(BE.PAQUETE paquete)
        {
            _mapper.Eliminar(paquete);

            var usuario = SEC.SESSION_MANAGER.GetInstance.Usuario;
            _bitacora.RegistrarEvento(usuario.Id, usuario.Username,
                "Paquetes", $"Se dio de baja el paquete: {paquete.Destino}", "WARNING");
        }
    }
}