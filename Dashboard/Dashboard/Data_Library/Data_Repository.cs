using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dashboard.Data_Library;
//using MediationDB.FormLibrary;
//using DevExpress.XtraPrinting.Preview;
//using DevExpress.XtraReports;
//using MediationDB.ReportsLibrary;


namespace Gestock.DataLibrary
{
    public class Data_Repository
    {
        static SqlConnection cnx;
        Params prms = new Params();
        public Data_Repository()
        {
            //prms.Serveur = "unhserver.database.windows.net"; 
            //prms.Base_de_donnees = "db_foncier";
            //prms.Nom_user = "Lens";
            //prms.Mot_de_passe = "unhabitat@@2020";
            //prms.Serveur = "DESKTOP-PO0I2OH";
            //prms.Base_de_donnees = "db_foncier";
            //prms.Nom_user = "sa";
            //prms.Mot_de_passe = "Windy@2019.com?";
            prms.Serveur = "DESKTOP-VIA78VL";
            prms.Base_de_donnees = "gestock_medical";
            prms.Nom_user = "sa";
            prms.Mot_de_passe = "Windy@2020.com?";
            //prms.Serveur = "DESKTOP-LSH2J11\\UNHABITAT_SERVER";
            //prms.Base_de_donnees = "db_foncier";
            //prms.Nom_user = "sa";
            //prms.Mot_de_passe = "UNH@PKA2020";

        }
        public void afficher_pharmacien(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_pharmacien", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void ajouter_pharmacien(string matricule, string noms, string telephone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("ajouter_pharmacien", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("matricule_pharmacien", SqlDbType.NVarChar)).Value = matricule;
                cmd.Parameters.Add(new SqlParameter("noms", SqlDbType.NVarChar)).Value = noms;
                cmd.Parameters.Add(new SqlParameter("contact", SqlDbType.NVarChar)).Value = telephone;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_pharmacien(string matricule, string noms, string telephone)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_pharmacien", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("matricule_pharmacien", SqlDbType.NVarChar)).Value = matricule;
                cmd.Parameters.Add(new SqlParameter("noms", SqlDbType.NVarChar)).Value = noms;
                cmd.Parameters.Add(new SqlParameter("contact", SqlDbType.NVarChar)).Value = telephone;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_pharmacien(string matricule)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_pharmacien", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("matricule_pharmacien", SqlDbType.NVarChar)).Value = matricule;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_mediateur(DataGridView dtg, string id_mediateur)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_mediateur", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_mediateur", SqlDbType.NVarChar)).Value = id_mediateur;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_type_conflit(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_type_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_type_conflit(string id_type_conflit, string descr_type_conflit)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_type_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_type_conflit", SqlDbType.NVarChar)).Value = id_type_conflit;
                cmd.Parameters.Add(new SqlParameter("descr_type_conflit", SqlDbType.NVarChar)).Value = descr_type_conflit;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_type_conflit(string id_type_conflit)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_type_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_type_conflit", SqlDbType.NVarChar)).Value = id_type_conflit;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_type_conflit(DataGridView dtg, string id_type_conflit)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_type_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_type_conflit", SqlDbType.NVarChar)).Value = id_type_conflit;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_causes_conflit(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_causes_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_causes_conflit(string id_cause_conflit, string descr_causes)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_causes_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_cause_conflit", SqlDbType.NVarChar)).Value = id_cause_conflit;
                cmd.Parameters.Add(new SqlParameter("descr_causes", SqlDbType.NVarChar)).Value = descr_causes;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_cause_conflit(string id_cause_conflit)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_cause_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_cause_conflit", SqlDbType.NVarChar)).Value = id_cause_conflit;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_cause_conflit(DataGridView dtg, string id_cause_conflit)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_cause_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_cause_conflit", SqlDbType.NVarChar)).Value = id_cause_conflit;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_objet_conflit(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_objet_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_objet_conflit(string id_objets_conflits, string descr_objet_conflits)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_objet_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_objets_conflits", SqlDbType.NVarChar)).Value = id_objets_conflits;
                cmd.Parameters.Add(new SqlParameter("descr_objet_conflits", SqlDbType.NVarChar)).Value = descr_objet_conflits;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_objet_conflit(string id_objets_conflits)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_objet_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_objets_conflits", SqlDbType.NVarChar)).Value = id_objets_conflits;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_objet_conflit(DataGridView dtg, string id_objets_conflits)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_objet_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_objets_conflits", SqlDbType.NVarChar)).Value = id_objets_conflits;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_nature_conflit(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_nature_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_nature_conflit(string id_nature_conflit, string descr_nature_conflit)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_nature_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_nature_conflit", SqlDbType.NVarChar)).Value = id_nature_conflit;
                cmd.Parameters.Add(new SqlParameter("descr_nature_conflit", SqlDbType.NVarChar)).Value = descr_nature_conflit;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void supprimer_nature_conflit(string id_nature_conflit)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("supprimer_nature_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_nature_conflit", SqlDbType.NVarChar)).Value = id_nature_conflit;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void search_nature_conflit(DataGridView dtg, string id_nature_conflit)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_nature_conflit", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_nature_conflit", SqlDbType.NVarChar)).Value = id_nature_conflit;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void afficher_type_partie(DataGridView dtg)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("afficher_type_partie", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }
        public void enregistrer_type_parties(string id_typ_partie, string descr_typ_partie)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("enregistrer_type_parties", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_typ_partie", SqlDbType.NVarChar)).Value = id_typ_partie;
                cmd.Parameters.Add(new SqlParameter("descr_typ_partie", SqlDbType.NVarChar)).Value = descr_typ_partie;
                cmd.ExecuteNonQuery();
                //afficher_frais(dtg);
                MessageBox.Show("Enregistrement avec succès!", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception tdf)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Voulez vous voir le code d'erreur?", "Erreurs ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(tdf.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }

        public void search_type_partie(DataGridView dtg, string id_typ_partie)
        {
            cnx = new SqlConnection(prms.ToString());
            try
            {
                if (cnx.State == ConnectionState.Closed)
                    cnx.Open();
                var cmd = new SqlCommand("search_type_partie", cnx)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("id_typ_partie", SqlDbType.NVarChar)).Value = id_typ_partie;
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dtg.DataSource = dt;
            }
            catch (Exception exct)
            {
                var rs = new DialogResult();
                rs = MessageBox.Show("Want to see error code?", "Errors ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    MessageBox.Show(exct.ToString());
                }
            }
            finally
            {
                cnx.Close(); cnx.Dispose();
            }
        }

    }
}

