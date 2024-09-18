﻿namespace LogicaNegocio
{
    public class Sistema
    {
        // Cliente hereda de Usuario
        private List<Usuario>_usuarios = new List<Usuario>();
        private List<Articulo>_articulos = new List<Articulo>();
        
        // Subastas y ofertas heredan de Publiaciones
        private List<Publicacion>_publicaciones = new List<Publicacion>();
    }
}
