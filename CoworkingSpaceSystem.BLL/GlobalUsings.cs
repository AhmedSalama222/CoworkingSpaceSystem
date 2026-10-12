// System & Collections
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using System.ComponentModel.DataAnnotations;

// ASP.NET Core Abstractions (للصور والـ Hosting)
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Hosting;

// AutoMapper
global using AutoMapper;

// Project Layer References (DAL & BLL Contracts)
global using CoworkingSpaceSystem.DAL.Entities;
global using CoworkingSpaceSystem.DAL.Repositories.Interfaces;
global using CoworkingSpaceSystem.BLL.DTOs.SpaceDTOs;
global using CoworkingSpaceSystem.BLL.Services.Interfaces;
global using CoworkingSpaceSystem.BLL.Helpers;