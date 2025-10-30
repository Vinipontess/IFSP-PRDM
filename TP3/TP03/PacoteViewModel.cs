using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP03
{
    public class PacoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<PacoteModel> _pacotes;
        private PacoteModel _pacote;

        public List<PacoteModel> Pacotes
        {
            get { return _pacotes; }
            set
            {
                _pacotes = value;
                OnPropertyChanged();
            }
        }

        public PacoteModel Pacote
        {
            get { return _pacote; }
            set
            {
                _pacote = value;
                OnPropertyChanged();
            }
        }

        public PacoteViewModel()
        {
            _pacotes = new List<PacoteModel>
            {
                // Pacote 1: Entregue
                new PacoteModel
                {
                    PacoteId = "BR420BRL",
                    Status = "Concluído (Entregue)",
                    DataEnvio = DateTime.Now.AddDays(-10),
                    DataPrevistaEntrega = DateTime.Now.AddDays(-2),
                    HistoricoEventos = new List<string>
                    {
                        "Item postado e recebido no centro de triagem.",
                        "Em transferência para a unidade de distribuição local.",
                        "Saída para entrega ao destinatário.",
                        "Objeto entregue em 28/10/2025."
                    }
                },
                new PacoteModel
                {
                    PacoteId = "SP999BRX",
                    Status = "Aguardando retirada na Agência",
                    DataEnvio = DateTime.Now.AddDays(-7),
                    DataPrevistaEntrega = DateTime.Now.AddDays(3),
                    HistoricoEventos = new List<string>
                    {
                        "Item postado na agência de origem.",
                        "Objeto não localizado no fluxo postal.",
                        "Reencaminhado ao centro de distribuição. Novo prazo de entrega.",
                        "Aguardando retirada pelo destinatário na agência X."
                    }
                },
                new PacoteModel
                {
                    PacoteId = "MG111ABC",
                    Status = "Em viagem para o destino final",
                    DataEnvio = DateTime.Now.AddDays(-1),
                    DataPrevistaEntrega = DateTime.Now.AddDays(5),
                    HistoricoEventos = new List<string>
                    {
                        "Objeto recebido na unidade de tratamento.",
                        "Em trânsito de Belo Horizonte/MG para Porto Alegre/RS."
                    }
                },
            };
        }

        public async Task BuscarInformacoesPacoteAsync(string codigoRastreamento)
        {
            var pacoteEncontrado = _pacotes.FirstOrDefault(p => p.PacoteId.Equals(codigoRastreamento, StringComparison.OrdinalIgnoreCase));

            if (pacoteEncontrado != null)
            {
                Pacote = pacoteEncontrado;
            }
            else
            {
                Pacote = null;
                await Application.Current.MainPage.DisplayAlert("Pacote não encontrado", "Desculpe! O pacote não foi encontrado. Verifique o código digitado e tente novamente.", "Ok");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}