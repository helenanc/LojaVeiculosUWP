using LojaApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LojaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            PopularCB();
        }

        //private string ip = "http://192.168.0.23";

        private void PopularCB()
        {
            Loja db = new Loja();
            if (cbVeicFab.Items.Count > 0)
                cbVeicFab.ItemsSource = null;
            cbVeicFab.ItemsSource = db.Fabricantes.Select(x => x.Descricao).ToList();
        }

        private bool SitVen()
        {
            if (cbSitVenda.SelectedItem.ToString() == "Vendido") return true;
            else return false;
        }

        /* BOTÕES CRUD */

        private void btnFabInsert_Click(object sender, RoutedEventArgs e)
        {
            Loja db = new Loja();
            Fabricante f = new Fabricante
            {
                Id = int.Parse(textFabId.Text),
                Descricao = textFabDesc.Text
            };

            db.Fabricantes.Add(f);
            db.SaveChanges();
            ListarFabs();
            PopularCB();
        }

        private void btnFabListas_Click(object sender, RoutedEventArgs e)
        {
            ListarFabs();
        }

        private void btnVeicInsert_Click(object sender, RoutedEventArgs e)
        {
            Loja db = new Loja();
            Fabricante f = db.Fabricantes.ToList().Find(x => x.Descricao == cbVeicFab.SelectedItem.ToString());
            Veiculo v = new Veiculo
            {
                Id = int.Parse(textVeicId.Text),
                Modelo = textVeicModelo.Text,
                Ano = int.Parse(textVeicAno.Text),
                Preco = double.Parse(textVeicPreco.Text),
                Vendido = SitVen(),
                Fabricante = f,
                IdFabricante = f.Id
            };

            db.Veiculos.Add(v);
            db.SaveChanges();
            ListarTodos();
        }

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            Loja db = new Loja();
            string[] z = listVeicDispo.SelectedItems[0].ToString().Split(' ');
            foreach (Veiculo veic in db.Veiculos)
                if (int.Parse(z[0]) == veic.Id)
                {
                    veic.Vendido = true;
                    db.SaveChanges();
                }
            ListarDisponivel();
            ListarVendido();
        }

        private void btnVeicListar_Click(object sender, RoutedEventArgs e)
        {
            ListarTodos();
        }

        private void btnListarVeicDispo_Click(object sender, RoutedEventArgs e)
        {
            ListarDisponivel();
        }

        private void btnListarVeicVend_Click(object sender, RoutedEventArgs e)
        {
            ListarVendido();
        }

        /* LISTAR */

        private void ListarFabs()
        {
            Loja db = new Loja();
            if (listFab.Items.Count > 0)
                listFab.ItemsSource = null;
            listFab.ItemsSource = db.Fabricantes.ToList();
        }

        private void ListarTodos()
        {
            Loja db = new Loja();
            if (listVeic.Items.Count != 0)
                listVeic.Items.Clear();
            listVeic.ItemsSource = db.Veiculos.ToList();
        }

        private void ListarDisponivel()
        {
            Loja db = new Loja();
            if (listVeicDispo.Items.Count > 0)
                listVeicDispo.ItemsSource = null;
            listVeicDispo.ItemsSource = db.Veiculos.Where(x => x.Vendido == false).ToList();
        }

        private void ListarVendido()
        {
            Loja db = new Loja();
            if (listVeicVend.Items.Count > 0)
                listVeicVend.ItemsSource = null;
            listVeicVend.ItemsSource = db.Veiculos.Where(x => x.Vendido == true).ToList();
        }

        private async void btnADispositivo_Click(object sender, RoutedEventArgs e)
        {/*
            AtualizarFab();
            AtualizarVei();
            PopularCB();
            MessageDialog dlg = new MessageDialog("Dispositivo atualizado com sucesso!");
            await dlg.ShowAsync();*/
        }

        private async void btnAServidor_Click(object sender, RoutedEventArgs e)
        {/*
            UparFab();
            UparVei();
            MessageDialog dlg = new MessageDialog("Servidor atualizado com sucesso!");
            await dlg.ShowAsync();*/
        }
    }
}
