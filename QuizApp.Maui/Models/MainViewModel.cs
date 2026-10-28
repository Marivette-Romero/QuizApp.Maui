using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Maui.Models
{
    public partial class MainViewModel: ObservableObject
    {
        [ObservableProperty]
        private string _textoDeLaPregunta; //Variables de Instancias
        [ObservableProperty]
        private string _resultado;

        private BancoDePreguntas _preguntas;
        private Pregunta _preguntaActual;

        public MainViewModel()
        {
            _preguntas = new BancoDePreguntas();
            _preguntaActual = _preguntas.ObtenerPrimerElemento();
            TextoDeLaPregunta = _preguntaActual.Texto;
            Resultado=string.Empty;
        }

        [RelayCommand]
        private void PreguntaSiguiente()
        {
            _preguntaActual=_preguntas.ObtenerElementoSiguiente();
            TextoDeLaPregunta= _preguntaActual.Texto;
            Resultado = string.Empty;
        }

        [RelayCommand]
        private void PreguntaAnterior()
        {
            _preguntaActual = _preguntas.ObtenerElementoAnterior();
            TextoDeLaPregunta = _preguntaActual.Texto;
            Resultado = string.Empty;
        }

        [RelayCommand]
        private void VerificarRespCierto()
        {
            VerificaResp(true);
        }
        [RelayCommand]
        private void VerificarRespFalso()
        {
            VerificaResp(false);
        }

        [RelayCommand]
        private void VerificaResp(bool boton)
        {
            if (boton == _preguntaActual.RespuestaEsCierto)
            {
                Resultado = "¡¡Correcto!! :D";
            }
            else
            {
                Resultado = "¡¡Incorrecto!! >:D";
            }
        }

    }
}
