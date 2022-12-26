using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//#3
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER" , bgl.baglanti());

            da.Fill(dt);
            gridControl1.DataSource = dt;
        }



        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
        }





        //#4 - Veri Kaydetme
        private void BtnKAYDET_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD, MARKA, MODEL, YIL, ADET, ALISFIYAT, SATISFIYAT, DETAY) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7, @p8)" , bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAD.Text);
            komut.Parameters.AddWithValue("@p2", TxtMARKA.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYIL.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudADET.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", TxtALIS.Text);
            komut.Parameters.AddWithValue("@p7", TxtSATIS.Text);
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);

            komut.ExecuteNonQuery(); 
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listele();
        }

        //#5 - Veri Silme
        private void BtnSIL_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TBL_URUNLER where ID=@p1", bgl.baglanti());

            komutsil.Parameters.AddWithValue("@p1", TxtID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Error);
            

            listele();
        }

        //#6
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtAD.Text = dr["URUNAD"].ToString();
            TxtMARKA.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskYIL.Text = dr["YIL"].ToString();
            NudADET.Value =decimal.Parse( dr["ADET"].ToString());
            TxtALIS.Text = dr["ALISFIYAT"].ToString();
            TxtSATIS.Text = dr["SATISFIYAT"].ToString();
           TxtALIS.Text = dr["ALISFIYAT"].ToString();
            RchDetay.Text = dr["DETAY"].ToString();
        }

        //#7 - Veri Güncelleme
        private void BtnGUNCELLE_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set URUNAD=@p1, MARKA=@p2, MODEL=@p3, YIL=@p4, ADET=@p5, ALISFIYAT=@p6, SATISFIYAT=@p7, DETAY=@p8 where ID=@p9", bgl.baglanti());


            komut.Parameters.AddWithValue("@p1", TxtAD.Text);
            komut.Parameters.AddWithValue("@p2", TxtMARKA.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYIL.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudADET.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", TxtALIS.Text);
            komut.Parameters.AddWithValue("@p7", TxtSATIS.Text);
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);


            komut.Parameters.Add("@p9", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            listele();

        }
    }
}
