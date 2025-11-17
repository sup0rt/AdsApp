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

namespace AdsApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Page
    {
        public MainForm()
        {
            InitializeComponent();
            LWads.ItemsSource = Entities.GetContext().Ads.ToList();
            cmbCategory.ItemsSource = Entities.GetContext().Categories.ToList();
            cmbStatus.ItemsSource = Entities.GetContext().Statuses.ToList();
            cmbType.ItemsSource = Entities.GetContext().Types.ToList();
            cmbCity.ItemsSource = Entities.GetContext().Cities.ToList();
        }

        private void UpdateAds()
        {
            var currentAds = Entities.GetContext().Ads.ToList();

            if (!string.IsNullOrWhiteSpace(TBsearch.Text))
            {
                string searchText = TBsearch.Text.ToLower();
                currentAds = currentAds.Where(a =>
                    a.ad_title.ToLower().Contains(searchText) ||
                    a.ad_description.ToLower().Contains(searchText)
                ).ToList();
            }

            if (cmbCategory.SelectedItem != null)
            {
                currentAds = currentAds.Where(a =>
                    a.category_id == cmbCategory.SelectedIndex + 1
                ).ToList();
            }

            if (cmbCity.SelectedItem != null)
            {
                currentAds = currentAds.Where(a =>
                    a.city_id == cmbCity.SelectedIndex + 1
                ).ToList();
            }

            if (cmbStatus.SelectedItem != null)
            {
                currentAds = currentAds.Where(a =>
                    a.status_id == cmbStatus.SelectedIndex + 1
                ).ToList();
            }

            if (cmbType.SelectedItem != null)
            {
                currentAds = currentAds.Where(a =>
                    a.type_id == cmbType.SelectedIndex + 1
                ).ToList();
            }

            LWads.ItemsSource = currentAds;
        }

        private void TBsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAds();
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAds();
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAds();
        }

        private void cmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAds();
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAds();
        }

        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            TBsearch.Text = "";
            cmbStatus.SelectedItem = null;
            cmbCategory.SelectedItem = null;
            cmbType.SelectedItem = null;
            cmbCity.SelectedItem = null;
            LWads.ItemsSource = Entities.GetContext().Ads.ToList();
        }
    }
}
