using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TesteAutoMapper.Core.DTOs;
using TesteAutoMapper.Models;

namespace TesteAutoMapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMapper _mapper;
        public MainWindow()
        {
            InitializeComponent();
            ConfigAutoMapper configAutoMapper = new ConfigAutoMapper();
            _mapper = configAutoMapper.GetConfig()
                .CreateMapper()
                .Build();
            CreateUserWithMapper();
        }
        UsuarioModel userM = new UsuarioModel
        {
            Id = 1,
            Name = "Fernando Bernardi",
            Perfil = new PerfilModel { Sexo = "Masculino"}
        };        
        public void CreateUserWithMapper()
        {
            // Resultado da conversão de UsuarioModel para UsuarioDTO
            UsuarioDTO usuario = _mapper.Map<UsuarioDTO>(userM);
        }
    }
}
