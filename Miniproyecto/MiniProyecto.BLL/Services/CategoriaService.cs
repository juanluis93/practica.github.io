using MiniProyecto.BLL.Contracts;
using MiniProyecto.BLL.core;
using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Models;
using MiniProyecto.BLL.Responses.CategoriaResponses;
using MiniProyecto.DAL.Entities;
using MiniProyecto.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProyecto.BLL.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoria _categorias;

        public CategoriaService(ICategoria categorias)
        {
            _categorias = categorias;
        }

        public CategoriaRemoveResponses Remove(CategoriaDTO categoriaDto)
        {
            CategoriaRemoveResponses result = new CategoriaRemoveResponses();
            try
            {
                MiniProyecto.DAL.Entities.Categoria categoria = new MiniProyecto.DAL.Entities.Categoria
                {
                    Descripcion = categoriaDto. Descripcion,
                    Nombre = categoriaDto.Nombre,
                    IDcategoria = categoriaDto.IDcategoria
                    
                };
                _categorias.Remove(categoria);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar eliminar la categoría: {ex}";
            }
            return result;
        }

        public CategoriaSaveResponses Save(CategoriaDTO categoriaDto)
        {
            CategoriaSaveResponses result = new CategoriaSaveResponses();
            try
            {
                MiniProyecto.DAL.Entities.Categoria categoria = new MiniProyecto.DAL.Entities.Categoria
                {
                    Descripcion = categoriaDto.Descripcion,
                    Nombre = categoriaDto.Nombre,
                    IDcategoria = categoriaDto.IDcategoria
                };
                _categorias.Save(categoria);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar guardar la categoría: {ex}";
            }
            return result;
        }

        public CategoriaUpdateResponses Update(CategoriaDTO categoriaDto)
        {
            CategoriaUpdateResponses result = new CategoriaUpdateResponses();
            try
            {
                MiniProyecto.DAL.Entities.Categoria categoria = new MiniProyecto.DAL.Entities.Categoria
                {
                    Descripcion = categoriaDto.Descripcion,
                    Nombre = categoriaDto.Nombre,
                    IDcategoria = categoriaDto.IDcategoria
                };
                _categorias.Update(categoria);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al intentar actualizar la categoría: {ex}";
            }
            return result;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from categoria in this._categorias.GetEntities()
                             select new CategoriaModel
                             {
                                 Descripcion = categoria.Descripcion,
                                 Nombre = categoria.Nombre,
                                 IDcategoria = categoria.IDcategoria
                             }).ToList();
                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al obtener las categorías: {ex}";
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                MiniProyecto.DAL.Entities.Categoria categoria = _categorias.GetEntity(id);
                CategoriaModel categoriaModel = new CategoriaModel
                {
                    Descripcion = categoria.Descripcion,
                    Nombre = categoria.Nombre,
                    IDcategoria = categoria.IDcategoria
                };
                result.Data = categoriaModel;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error al obtener la categoría: {ex}";
            }
            return result;
        }
    }
}