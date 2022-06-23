using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomobileLibraby.BussinessObject;
using AutomobileLibraby.Repository;

namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        public frmCarDetails()
        {
            InitializeComponent();
        }
        //----------------------------------------//
        public ICarRepository carRepository { get; set; }
        public bool InsertOrUpdate { get; set; } //false: insert, true: update
        public Car carInfo { get; set; }
        //----------------------------------------//
        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            cboManafacturer.SelectedIndex = 0;
            txtCarID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtCarID.Text = carInfo.CarId.ToString();
                txtCarName.Text = carInfo.CarName;
                txtPrice.Text = carInfo.Price.ToString();
                txtReleaseYear.Text = carInfo.ReleaseYear.ToString();
                cboManafacturer.Text = carInfo.Manufacturer.Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarId = int.Parse(txtCarID.Text),   
                    CarName = txtCarName.Text,
                    Manufacturer = cboManafacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text)
                };
                if (InsertOrUpdate == false)
                {
                    carRepository.InsertCar(car);
                }
                else
                {
                    carRepository.UpdateCar(car);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new car" : "Update a car");
            }
        }

        private void btnCanCel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
