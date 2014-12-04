﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpaceTraders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlanetScreen : Page
    {
        private GameInstance gi;
        private Planet curPlanet;
        private Player player;

        public PlanetScreen()
        {
            this.InitializeComponent();
            gi = GameInstance.getInstance();
            curPlanet = gi.getCurrentPlanet();
            player = gi.getPlayer();
            Random r = new Random();
            ColorList cl = new ColorList();
            PlanetImg.Fill = new SolidColorBrush(cl.ElementAt(r.Next(cl.Count)));
            Refuel.Content = "Refuel: " + player.getRefuelCost() + " cr";
            TitleScreen.Text = curPlanet.getName();
            Description.Text = curPlanet.toString() + "\n Resources:  "
                               + curPlanet.getResource().toString() + "\n\nFuel: " + player.getCurrentFuel()
                               + "\nMoney: "
                               + player.getMoney();

            if (curPlanet.getTechLevel().Equals(TechLevel.POST_INDUSTRIAL))
            {
                enterShipyard.IsEnabled = true;
            }
            else if (curPlanet.getTechLevel().Equals(TechLevel.HI_TECH))
            {
                enterShipyard.IsEnabled = true;
            }
            else
            {
                enterShipyard.IsEnabled = false;
            }

        }

        private void ToMap_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (MapScreen));
        }

        private void enterMarket_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (MarketScreen));
        }

        private void enterShipyard_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (ShipyardScreen));
        }

        private void Refuel_Click(object sender, RoutedEventArgs e)
        {
            player.buyFuel();
            Description.Text = curPlanet.toString() + "\n Resources:  "
                               + curPlanet.getResource().toString() + "\n\nFuel: " + player.getCurrentFuel()
                               + "\nMoney: "
                               + player.getMoney();
            Refuel.Content = "Refuel: " + 0 + " cr";
        }
    }
}
