﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogicaNegocio
{

    public abstract class Publicacion:IValidate
    {
        private string _id;
        private static int s_ultimoID = 1;

        private string _nombre;

        // Estado puede ser: ABIERTA, CANCELADA, CERRADA
        protected string _estado;

        // Fecha de publicacion y finalizacion de la publicacion
        protected DateTime _fechaPublicacion;
        protected DateTime _fechaFinalizacion;

        // Lista de articulos dentro de la publicacion
        private List<Articulo> _articulos = new List<Articulo>();

        // Cliente que realizo la compra
        protected Cliente _comprador = null;

        // En el caso de una subasta el finalizador es un usuario de tipo Administrador
        // mientras que en el caso de una compra el finalizador es un usuario de tipo Cliente
        protected Usuario _finalizador = null;

        // Es el método constructor de la clase publicacion que se usará para crear instancias del tipo publicacion.
        public Publicacion(string nombre, string estado, DateTime fechaPublicacion, Cliente comprador, Usuario finalizador)
        {
            this._id = $"PUB{s_ultimoID + 1}";
            s_ultimoID++;
            this._nombre = nombre;
            this._estado = estado;
            this._fechaPublicacion = fechaPublicacion;
            this._comprador = comprador;
            this._finalizador = finalizador;
            this._articulos = new List<Articulo>();
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        
        public Cliente Comprador
        {
            get { return _comprador; }
            set { _comprador = value; }
        }

        public Usuario Finalizador
        {
            get { return _finalizador; }
            set { _finalizador = value; }
        }
        
        // Propiedad que devuelve la lista de articulos de una instancia de tipo publicacion.
        public List<Articulo> Articulo
        {
            get
            {
                return _articulos;
            }
        }
        // Propiedad que devuelve el ID de una instancia de tipo publicacion.
        public string Id
        {
            get { return _id; }
        }
        // Propiedad que devuelve la fecha de publicacion de una instancia de tipo publicacion.
        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
        }

        public DateTime FechaFinalizacion
        {
            get { return _fechaFinalizacion;}
            set { _fechaFinalizacion = value; }
        }
        
        public string Nombre
        {
            get { return _nombre; }
        }

        // Método polimorfico que retorna precio de una publicación
        public abstract double Precio();

        public override bool Equals(object obj)
        {
            bool sonIguales = false;
            if (obj != null && obj is Publicacion)
            {
                Publicacion publicacion = (Publicacion)obj;
                sonIguales = _nombre == publicacion._nombre;
            }
            return sonIguales;
        }

        public void AgregarArticulo(Articulo articulo) {

            if (articulo != null && !_articulos.Contains(articulo)){
                _articulos.Add(articulo);
            }
        }
        
        // Metodo que modifica el comportamiento del método ToString de la clase publicación, permitiendo imprimir los atributos nombre, estado, fecha de publicación e ID.
        public override string ToString()
        {
            return $"Nombre: {_nombre}. Estado: {_estado}. Fecha de publicacion: {_fechaPublicacion}. ID: {_id}";
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) {
                throw new Exception("El nombre no puede estar vacio.");
            }
            else if (string.IsNullOrEmpty(_estado)) {
                throw new Exception("El estado no puede estar vacio.");
            }
       }
    }
}
