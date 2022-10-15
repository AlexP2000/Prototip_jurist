

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Prototip_jurist
{
    public partial class Form1 : Form
    {
        DataTableCollection tableCollection;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

        }

        private void Alege_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    Cale.Text = ofd.FileName;
                    var Fs = File.Open(Cale.Text, FileMode.Open, FileAccess.Read);
                    var reader = ExcelReaderFactory.CreateReader(Fs);
                    var rezult = reader.AsDataSet();
                    var tables = rezult.Tables.Cast<DataTable>();
                    tableCollection = rezult.Tables;
                    foreach (DataTable dataTable in tables)
                    {
                        Foaie.Items.Add(dataTable.TableName);
                    }


                }
            }
        }

        private void Foaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[Foaie.SelectedItem.ToString()];
            afisare_tabel.DataSource = dt;
        }



        private void afisare_tabel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                NumeSocietate.Text = afisare_tabel.SelectedRows[0].Cells[0].Value.ToString();
                Forma_de_activitate.Text = afisare_tabel.SelectedRows[0].Cells[1].Value.ToString();
                Oras.Text = afisare_tabel.SelectedRows[0].Cells[2].Value.ToString();
                judet.Text = afisare_tabel.SelectedRows[0].Cells[3].Value.ToString();
                Strada.Text = afisare_tabel.SelectedRows[0].Cells[4].Value.ToString();
                NumarStrada.Text = afisare_tabel.SelectedRows[0].Cells[5].Value.ToString();
                Bloc.Text = afisare_tabel.SelectedRows[0].Cells[6].Value.ToString();
                Scara.Text = afisare_tabel.SelectedRows[0].Cells[7].Value.ToString();
                etaj.Text = afisare_tabel.SelectedRows[0].Cells[8].Value.ToString();
                Ap.Text = afisare_tabel.SelectedRows[0].Cells[9].Value.ToString();
                NORC.Text = afisare_tabel.SelectedRows[0].Cells[10].Value.ToString();
                CUI.Text = afisare_tabel.SelectedRows[0].Cells[11].Value.ToString();
                telefon.Text = afisare_tabel.SelectedRows[0].Cells[12].Value.ToString();
                Cont.Text = afisare_tabel.SelectedRows[0].Cells[13].Value.ToString();
                Deschis.Text = afisare_tabel.SelectedRows[0].Cells[14].Value.ToString();
                sucursala.Text = afisare_tabel.SelectedRows[0].Cells[15].Value.ToString();
                reprezentat.Text = afisare_tabel.SelectedRows[0].Cells[16].Value.ToString();
                functia.Text = afisare_tabel.SelectedRows[0].Cells[17].Value.ToString();

            }
        }

        private void Genereaza_contract_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 30, 30);
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("contracte/Redenumiti acest fisier astfel incat sa il puteti indentifica.pdf", FileMode.Create));
            doc.Open();

            Paragraph p = new Paragraph("                    " + "SERVICIUL LOCAL „ECO VALEA MUNTELUI COMANESTI”");
            p.Font.SetStyle(1);

            p.Font.Size = 15;
            doc.Add(p);
            Paragraph q = new Paragraph("                                                     " + "Comanesti, str. Moldovei nr.118, ");

            doc.Add(q);
            Paragraph r = new Paragraph("                                                   " + "Tel: 0234-370.066 ; Fax : 0234-370.049");

            doc.Add(r);
            Paragraph t = new Paragraph("                                                        " + "C.I.F.: RO 40101462");

            doc.Add(t);
            Paragraph z = new Paragraph("                                                    " + "CONTRACT");
            z.Font.SetStyle(1);

            z.Font.Size = 15;
            doc.Add(z);
            Paragraph pw = new Paragraph("                                              " + "de prestare a serviciului de salubrizare a localitatilor");

            doc.Add(pw);
            Paragraph pt = new Paragraph("                                                        " + "Nr. " + Nr.Text + " " + "din " + Data.Text);

            doc.Add(pt);
            Paragraph pr = new Paragraph("                                                                  " + "CAPITOLUL I");
            pr.Font.SetStyle(1);
            doc.Add(pr);
            Paragraph py = new Paragraph("                                                               " + "Partile contractante");

            doc.Add(py);
            Paragraph pu = new Paragraph("     Art.1. a)  " + NumeSocietate1.Text + ", " + "cu sediul în str. " + strada1.Text + ", nr. " + Numar1.Text + ", oras: " + oras1.Text + ", judetul: " + judet1.Text + ", cod postal " + Codpostal1.Text + ", Cod Identificare Fiscala: " + Coddeindentificarefiscala1.Text + ", tel." + telefon1.Text + ", /fax: " + fax1.Text + ", cont: " + cont1.Text + ", deschis la: " + deschis1.Text + " " + sucursala1.Text + ", reprezentata prin: " + reprezentant1.Text + ", avand functia de: " + functia1.Text + " - pe de o parte");

            doc.Add(pu);
            Paragraph pi = new Paragraph("Si");

            doc.Add(pi);
            Paragraph po = new Paragraph("b) " + NumeSocietate.Text + " " + Forma_de_activitate.Text + " " + ", cu sediul social in orasul: " + Oras.Text + ", judetul: " + judet.Text + ", std.: " + Strada.Text + ", numarul: " + NumarStrada.Text + ", bloc: " + Bloc.Text + ", scara: " + Scara.Text + ", etaj: " + etaj.Text + ", Ap: " + Ap.Text + ", numar de ordine la registrul comertului: " + NORC.Text + ", C.U.I: " + CUI.Text + ", tel/fax: " + telefon.Text + ", cont: " + Cont.Text + ", deschis la: " + Deschis.Text + " " + sucursala.Text + ", reprezentata de: " + reprezentat.Text + ", avand functia de: " + functia.Text + ", pe de alta parte, au convenit sa încheie prezentul contract de prestari de servicii de colectare a deseurilor de tip municipal, cu respectarea urmatoarelor clauze: ");

            doc.Add(po);
            Paragraph pp = new Paragraph("                                                                  " + "CAPITOLUL II");
            pp.Font.SetStyle(1);
            doc.Add(pp);
            Paragraph a = new Paragraph("                                                               " + "Obiectul contractului");

            doc.Add(a);
            Paragraph s = new Paragraph("      Art.2. -  Obiectul prezentului contract îl constituie prestarea activitatii de colectare a deseurilor municipale.  ");

            doc.Add(s);
            Paragraph d = new Paragraph("      Art.3. -  Operatorul va presta activitatea de ridicare a deseurilor municipale din locatia situata în orasul: " + Oras.Text + ", judetul: " + judet.Text + ", strada: " + Strada.Text + ", numarul: " + NumarStrada.Text + ", bloc: " + Bloc.Text + ", scara: " + Scara.Text + ", etaj: " + etaj.Text + ", ap: " + Ap.Text + ".");

            doc.Add(d);
            Paragraph f = new Paragraph("      Art.4. -  Prezentul contract s-a încheiat pentru o cantitate de 0,20 mc./luna si 0 eurocontanier/re.    ");

            doc.Add(f);
            Paragraph g = new Paragraph("      Art.5. – (1) Contractul de prestare a activitatii de colectare a deseurilor municipale se incheie între operator şi utilizator pe o durată nedeterminată.    ");

            doc.Add(g);
            Paragraph h = new Paragraph("(2) Contractul poate inceta în urmatoarele cazuri:  ");

            doc.Add(h);
            Paragraph i = new Paragraph("a)  prin acordul scris al partilor; ");

            doc.Add(i);
            Paragraph j = new Paragraph("b) prin denuntare unilaterala de utilizator, cu un preaviz de 30 de zile, dupa achitarea la zi a tuturor debitelor datorate catre operator;  ");

            doc.Add(j);
            Paragraph k = new Paragraph("c) prin denuntare unilaterala de catre operator, în cazul neachitarii contravalorii serviciilor prestate în termen de 30 de zile calendaristice de la data expirarii termenului de plata a facturii, cu acordul autoritatii administraţiei publice locale care va aplica incepand cu data incetarii contractului taxa de salubrizare instituita conform prevederilor Legii serviciului de salubrizare a localitatilor nr. 101/2006;    ");

            doc.Add(k);
            Paragraph l = new Paragraph("d) prin reziliere; ");

            doc.Add(l);
            Paragraph x = new Paragraph("e) In cazul deschiderii procedurii de reorganizare judiciara si/sau faliment al operatorului.   ");

            doc.Add(x);
            Paragraph c = new Paragraph("(3) Masura rezilierii contractului se poate lua numai in urma unui preaviz adresat utilizatorului si se poate pune în aplicare dupa 15 zile lucratoare de la data primirii acestuia de către utilizator.");

            doc.Add(c);
            Paragraph v = new Paragraph("       Art.6. -  In anexa la contract sunt mentionate standardele, normativele şi gradul de continuitate a serviciului, valabile la data semnarii contractului. ");

            doc.Add(v);
            Paragraph b = new Paragraph("                                                                  " + "CAPITOLUL III");
            b.Font.SetStyle(1);
            doc.Add(b);
            Paragraph n = new Paragraph("                                               " + "Drepturile si obligatiile operatorului  ");

            doc.Add(n);
            Paragraph m = new Paragraph("       Art.7. -  Operatorul are urmatoarele drepturi:  ");

            doc.Add(m);
            Paragraph q1 = new Paragraph("a) sa incaseze lunar contravaloarea serviciilor prestate/contractate, corespunzator tarifului aprobat de autoritatile administratiei publice locale, determinat în conformitate cu normele metodologice elaborate si aprobate de A.N.R.S.C.;  ");

            doc.Add(q1);
            Paragraph q2 = new Paragraph("b) sa aplice penalitati egale cu nivelul dobanzii datorate pentru neplata la termen a obligatiilor bugetare, în cazul neachitarii facturilor la termen; ");

            doc.Add(q2);
            Paragraph q3 = new Paragraph("c) sa asigure echilibrul contractual pe durata contractului de prestari de servicii;   ");

            doc.Add(q3);
            Paragraph q4 = new Paragraph("d) sa initieze modificarea si completarea contractului de prestare a activitatii de colectare a deseurilor municipale sau a anexelor acestuia, ori de cate ori apar elemente noi în baza normelor legale, prin acte aditionale;   ");

            doc.Add(q4);
            Paragraph q5 = new Paragraph("e) sa solicite autoritatii administratiei publice locale acordul privind rezilierea contractului, considerarea utilizatorului ca fiind fara contract si obligarea acestuia la achitarea taxei speciale, instituita pentru astfel de cazuri;  ");

            doc.Add(q5);
            Paragraph q6 = new Paragraph("f) sa solicite recuperarea debitelor în instanta.    ");

            doc.Add(q6);
            Paragraph q7 = new Paragraph("      Art.8. -  Operatorul are urmatoarele obligatii:    ");

            doc.Add(q7);
            Paragraph q8 = new Paragraph("a) sa asigure prestarea activitatii de colectare a deseurilor municipale, conform prevederilor contractuale si cu respectarea regulamentului serviciului de salubrizare, prescriptiilor, normelor si normativelor tehnice în vigoare;     ");

            doc.Add(q8);
            Paragraph q9 = new Paragraph("b) sa respecte prevederile reglementarilor emise de autoritatile de reglementare si autoritatile administratiei publice locale;  ");

            doc.Add(q9);
            Paragraph q10 = new Paragraph("c) sa respecte indicatorii de performanta stabiliti prin hotararea de dare în administrare sau prin contractul de delegare a gestiunii si precizati in regulamentul serviciului de salubrizare, sa imbunatateasca in mod continuu calitatea serviciilor prestate;   ");

            doc.Add(q10);
            Paragraph q11 = new Paragraph("d) sa inregistreze toate reclamatiile si sesizările utilizatorului si sa ia masurile care se impun in vederea rezolvării acestora, în termen de maximum 30 de zile; ");

            doc.Add(q11);
            Paragraph q12 = new Paragraph("e) sa actualizeze impreuna cu autoritatile administratiei publice locale evidenta tuturor utilizatorilor cu si fara contracte de prestari de servicii, în vederea decontarii prestaţiei direct din bugetul local pe baza taxelor locale instituite in acest sens;  ");

            doc.Add(q12);
            Paragraph q13 = new Paragraph("f) sa presteze activitatea de colectare a deseurilor municipale la toti utilizatorii din raza unitatii administrativ-teritoriale pentru care are hotarare de dare în administrare sau contract de delegare a gestiunii; ");

            doc.Add(q13);
            Paragraph q14 = new Paragraph("g) sa asigure continuitatea serviciului, cu exceptia cazurilor de forta majora, asa cum sunt acestea definite prin lege;  ");

            doc.Add(q14);
            Paragraph q15 = new Paragraph("h) sa verifice integritatea recipientelor de colectare si sa le inlocuiasca în termen de maximum doua zile de la constatare sau de la sesizarea primita în acest sens, daca acestea nu mai asigura etanseitatea;  ");

            doc.Add(q15);
            Paragraph q16 = new Paragraph("i) sa plateasca penalizari in cuantum de 3% pe zi din valoarea facturii curente pentru:  ");

            doc.Add(q16);
            Paragraph w1 = new Paragraph("1. Intreruperea nejustificata a prestarii serviciului;   ");

            doc.Add(w1);
            Paragraph w2 = new Paragraph("2. Prestarea serviciului sub parametrii de calitate si cantitate prevazuti in contract;  ");

            doc.Add(w2);
            Paragraph w3 = new Paragraph("3. Neanuntarea intreruperii serviciului sau depasirea intervalului anuntat;   ");

            doc.Add(w3);
            Paragraph w4 = new Paragraph("4. neridicarea deseurilor la data si intervalul orar stabilite prin contract;   ");

            doc.Add(w4);
            Paragraph w5 = new Paragraph("j) sa doteze punctele de colectare cu recipiente de colectare, prin amplasarea acestora in locurile special amenajate stabilite de autoritatile administrasiei publice locale, etanse si adecvate mijloacelor de transport pe care le are in dotare, în cantitati suficiente pentru a asigura capacitatea de inmagazinare necesara pentru intervalul dintre doua ridicari consecutive; ");

            doc.Add(w5);
            Paragraph w6 = new Paragraph("k) sa inscriptioneze containerele si recipientele folosite pentru colectarea separata a diferitelor tipuri de materiale continute in deseurile municipale, cu denumirea materialului/materialelor pentru care sunt destinate si marcate in diverse culori prin vopsire sau aplicarea de folie adeziva, conform prevederilor legale in vigoare;   ");

            doc.Add(w6);
            Paragraph w7 = new Paragraph("l) sa suplimenteze capacitatea de înmagazinare, inclusiv prin marirea numarului de recipiente sau containere, in cazul in care se dovedeste ca volumul acestora este insuficient si se depoziteaza deseuri municipale în afara lor;   ");

            doc.Add(w7);
            Paragraph w8 = new Paragraph("m) sa inscriptioneze recipientele de colectare a deseurilor municipale, pentru a evita folosirea acestora fara drept, cu un marcaj de identificare realizat astfel incat să nu poate fi sters fara ca prin aceasta operatie sa nu ramana urme vizibile;  ");

            doc.Add(w8);
            Paragraph w9 = new Paragraph("n) sa colecteze deseurile folosind autovehicule special echipate pentru transportul deseurilor menajere; ");

            doc.Add(w9);
            Paragraph w10 = new Paragraph("o) sa ridice deseurile in zilele si in intervalul orar stabilite;    ");

            doc.Add(w10);
            Paragraph w11 = new Paragraph("p) sa încarce intreaga cantitate de deseuri, inclusiv deseurile municipale amplasate langa containerele de colectare, si sa lase in stare de curatenie spatiul destinat depozitarii;   ");

            doc.Add(w11);
            Paragraph w12 = new Paragraph("q) in cazul in care in/langa containerele de colectare sunt depozitare si deseuri din constructii, acestea vor fi colectate separat, dupa caz, instiintand in scris utilizatorul despre acest fapt si despre suma suplimentara ce va fi facturata pentru colectarea acelor deseuri;");

            doc.Add(w12);
            Paragraph w13 = new Paragraph("r) sa aseze după golire recipientele în pozitie normala, pe locul de unde au fost ridicate. Toate operatiunile vor fi efectuate astfel încat sa se evite producerea zgomotului si a altor inconveniente pentru utilizator;  ");

            doc.Add(w13);
            Paragraph w14 = new Paragraph("s) sa spele si sa dezinfecteze recipientele de colectare la 15 zile calendaristice în perioada 1 aprilie - 1 octombrie si la 30 de zile in restul perioadei din an;  ");

            doc.Add(w14);
            Paragraph w15 = new Paragraph("t) sa mentina in stare salubra punctele de colectare amplasate pe domeniul public si sa asigure desfasurarea corespunzatoare a programelor de dezinsectie, dezinfectie si deratizare, conform programelor aprobate de autoritatea administratiei publice locale; ");

            doc.Add(w15);
            Paragraph w16 = new Paragraph("u) sa aduca la cunostinta utilizatorilor modificarile de tarife si alte informatii necesare, prin adresa atasata facturii şi prin afişare la utilizatori.  ");

            doc.Add(w16);
            Paragraph w17 = new Paragraph("                                                                  " + "CAPITOLUL IV");
            w17.Font.SetStyle(1);
            doc.Add(w17);
            Paragraph w18 = new Paragraph("                                                      " + "Drepturile si obligatiile utilizatorului   ");

            doc.Add(w18);
            Paragraph w19 = new Paragraph("        Art.9. - Utilizatorul are urmatoarele drepturi:  ");

            doc.Add(w19);
            Paragraph w20 = new Paragraph("a) accesibilitate egala si nediscriminatorie la serviciul public, în conditii contractuale, în conditiile contractului de prestare;  ");

            doc.Add(w20);
            Paragraph e1 = new Paragraph("b) sa i se presteze activitatea de colectare a deseurilor municipale în ritmul si la nivelurile stabilite in contract; ");

            doc.Add(e1);
            Paragraph e2 = new Paragraph("c) sa solicite si sa primeasca, in conditiile legii si ale contractului de prestare, despagubiri sau compensatii pentru daunele provocate de catre operator prin nerespectarea obligatiilor contractuale asumate ori prin prestarea unor servicii inferioare, calitativ şi cantitativ, parametrilor tehnici stabiliti prin contract sau prin normele tehnice în vigoare;  ");

            doc.Add(e2);
            Paragraph e3 = new Paragraph("d) sa sesizeze autoritatilor administratiei publice locale si celei competente orice deficiente constatate în sfera activitatii de colectare a deseurilor municipale si sa faca propuneri vizand inlaturarea acestora, imbunatatirea activitatii si cresterea calitatii serviciului. ");

            doc.Add(e3);
            Paragraph e4 = new Paragraph("e) sa solicite, sa primeasca si sa utilizeze informatii privind activitatea de colectare a deseurilor municipale, despre deciziile luate in legatura cu acest serviciu de catre autoritatile administratiei publice locale, A.N.R.S.C. sau operator, dupa caz;  ");

            doc.Add(e4);
            Paragraph e5 = new Paragraph("f) sa primeasca raspuns în maximum 30 de zile la sesizarile adresate operatorului sau autoritatilor administratiei publice locale cu privire la neindeplinirea unor conditii contractuale;  ");

            doc.Add(e5);
            Paragraph e6 = new Paragraph("g) sa se adreseze, individual ori colectiv prin intermediul unor asociatii reprezentative, autoritatilor administratiei publice locale sau centrale ori instantelor judecătoresti, în vederea prevenirii sau repararii unui prejudiciu direct ori indirect;  ");

            doc.Add(e6);
            Paragraph e7 = new Paragraph("h) sa conteste facturile cand constata incalcarea prevederilor contractuale;  ");

            doc.Add(e7);
            Paragraph e8 = new Paragraph("i) sa beneficieze, inclusiv la cererea sa, de tarif diferentiat, stimulativ pentru colectarea selectiva a deseurilor municipale;  ");

            doc.Add(e8);
            Paragraph e9 = new Paragraph("j) sa renunte, in conditiile legii, la serviciile contractate.");

            doc.Add(e9);
            Paragraph e10 = new Paragraph("    Art.10. -  Utilizatorul are următoarele obligaţii:  ");

            doc.Add(e10);
            Paragraph e11 = new Paragraph("a) sa respecte prevederile regulamentului serviciului de salubrizare si clauzele contractului de prestare a activitatii de colectare a deseurilor municipale;  ");

            doc.Add(e11);
            Paragraph e12 = new Paragraph("b) sa achite în termenele stabilite obligatiile de plata, in conformitate cu prevederile contractului de prestare a activitatii de colectare a deseurilor municipale;   ");

            doc.Add(e12);
            Paragraph e13 = new Paragraph("c) sa nu impiedice în niciun fel accesul utilajelor de colectare a deseurilor la punctele de colectare;  ");

            doc.Add(e13);
            Paragraph e14 = new Paragraph("d) sa comunice in scris operatorului, în termen de 10 zile lucratoare, orice modificare a elementelor care au stat la baza intocmirii contractului si sa incheie acte aditionale in legatura cu acestea, modificarea numarului de persoane se comunica de catre utilizator trimestrial, daca este cazul;   ");

            doc.Add(e14);
            Paragraph e15 = new Paragraph("e) sa nu modifice amplasarea recipientelor destinate precolectarii deseurilor menajere;   ");

            doc.Add(e15);
            Paragraph e16 = new Paragraph("f) sa suporte costurile de remediere sau inlocuire a recipientelor de precolectare, in cazul deteriorarii acestora din vina dovedita a utilizatorului;   ");

            doc.Add(e16);
            Paragraph e17 = new Paragraph("g) sa asigure preselectarea pe categorii a deseurilor reciclabile, rezultate din gospodăriile proprii sau din activitatile lucrative pe care le desfaşoara, precum si depozitarea acestora în containere asigurate de operatorul serviciului de salubrizare în acest scop;  ");

            doc.Add(e17);
            Paragraph e18 = new Paragraph("h) sa aplice masuri privind deratizarea şi dezinsectia, stabilite de autoritatea locala si de directia de sanatate publica teritoriala; ");

            doc.Add(e18);
            Paragraph e19 = new Paragraph("i) sa accepte intreruperea temporara a prestarii serviciului pentru/ca urmare a executiei unor lucrari prevazute în programele de reabilitare, extindere si modernizare a infrastructurii tehnico-edilitare;  ");

            doc.Add(e19);
            Paragraph e20 = new Paragraph("j) sa execute operatiunea de precolectare în recipientele cu care sunt dotate punctele de colectare, in conformitate cu sistemul de colectare convenit de operator cu autoritatile administratiei publice locale si stabilite prin contract. Fractiunea umeda a deseurilor va fi depusa obligatoriu in saci de plastic si apoi în recipientul de colectare destinat special în acest scop;   ");

            doc.Add(e20);
            Paragraph r1 = new Paragraph("k) sa primeasca, la cerere, de la operator pungi/saci de plastic pentru colectarea selectiva a deseurilor reciclabile;   ");

            doc.Add(r1);
            Paragraph r2 = new Paragraph("l) sa mentina in stare de curatenie spatiile in care se face precolectarea, precum si recipientele in care se depoziteaza deseurile municipale in vederea colectarii, daca acestea se afla pe proprietatea lor; ");

            doc.Add(r2);
            Paragraph r3 = new Paragraph("m) sa execute operatiunea de precolectare în conditii de maxima siguranta din punctul de vedere al sanatatii oamenilor si al protectiei mediului, astfel încat sa nu produca poluare fonica, miros neplacut si raspandirea de deseuri;   ");

            doc.Add(r3);
            Paragraph r4 = new Paragraph("n) sa nu introduca in recipientele de precolectare deseuri din categoria celor cu regim special (periculoase, toxice, explozive), animaliere, provenite din constructii, din toaletarea pomilor sau curatarea si intretinerea spatiilor verzi ori provenite din ingrijiri medicale care fac obiectul unor tratamente speciale autorizate de directiile sanitare veterinare sau de autoritatile de mediu;  ");

            doc.Add(r4);
            Paragraph r5 = new Paragraph("o) sa asigure curatenia locurilor de parcare de resedinta pe care le au în folosinta din domeniul public, daca este cazul, si sa nu efectueze activitati de reparatii, întreţinere sau curatare a autovehiculelor, prin care pot produce scurgerea uleiurilor, carburantilor si lubrifiantilor;   ");

            doc.Add(r5);
            Paragraph r6 = new Paragraph("p) sa asigure accesul de la caile publice pana la punctul de colectare al autovehiculelor destinate acestui scop, inlaturand gheata, zapada si poleiul.  ");

            doc.Add(r6);
            Paragraph r7 = new Paragraph("                                                                  " + "CAPITOLUL V");
            r7.Font.SetStyle(1);
            doc.Add(r7);
            Paragraph r8 = new Paragraph("   " + "Colectarea deseurilor municipale, masurarea prestatiei activitatii de colectare a deseurilor municipale");

            doc.Add(r8);
            Paragraph r9 = new Paragraph("      Art.11. -  Colectarea deseurilor municipale se va face dupa cum urmeaza: ");

            doc.Add(r9);
            Paragraph r10 = new Paragraph("                                          ");

            doc.Add(r10);
            PdfPTable table = new PdfPTable(3);
            table.AddCell("Perioada");
            table.AddCell("Zile din saptamana in care se va face colectarea");
            table.AddCell("Interval orar");

            table.AddCell("1 octombrie - 1 aprilie");
            table.AddCell("Marti");
            table.AddCell("08-16");

            table.AddCell("1 octombrie - 1 aprilie");
            table.AddCell("Vineri");
            table.AddCell("08-16");

            table.AddCell("1 aprilie - 1 octombrie");
            table.AddCell("Marti");
            table.AddCell("07-16");

            table.AddCell("1 aprilie - 1 octombrie");
            table.AddCell("Vineri");
            table.AddCell("07-16");
            doc.Add(table);
            Paragraph r11 = new Paragraph("                                                                  " + "CAPITOLUL VI");
            r11.Font.SetStyle(1);
            doc.Add(r11);
            Paragraph r12 = new Paragraph("                                                 " + "Tarife, facturare si modalitati de plata  ");

            doc.Add(r12);
            Paragraph r13 = new Paragraph("        Art.12. -(1) Operatorii vor practica tarifele aprobate de autoritatile administratiei publice locale, potrivit prevederilor legale in vigoare.   ");

            doc.Add(r13);
            Paragraph r14 = new Paragraph("(2) Stabilirea, ajustarea ori modificarea tarifelor se va face potrivit prevederilor legale.   ");

            doc.Add(r14);
            Paragraph r15 = new Paragraph("(3) Modificarea tarifelor va fi adusa la cunostinta utilizatorilor cu minimum 15 zile inaintea inceperii perioadei de facturare.  ");

            doc.Add(r15);
            Paragraph r16 = new Paragraph("(4) Tariful practicat:  ");

            doc.Add(r16);
            Paragraph r17 = new Paragraph("- pentru colectarea deseurilor municipale la incheierea contractului este de 139,06 lei/mc  ");

            doc.Add(r17);
            Paragraph r18 = new Paragraph(" - pentru inchiriere eurocontainer 20 lei/buc/luna. ");

            doc.Add(r18);
            Paragraph r19 = new Paragraph("        Art.13. -(1) Facturarea se face lunar, în baza preturilor di tarifelor aprobate si a cantitatilor efective determinate sau estimate potrivit prevederilor contractuale.   ");

            doc.Add(r19);
            Paragraph r20 = new Paragraph(" (2) Factura va cuprinde elementele de identificare ale fiecarui utilizator, cantitatile facturate, pretul/tariful aplicat, inclusiv baza legala.  ");

            doc.Add(r20);
            Paragraph t1 = new Paragraph("        Art.14. - (1) Factura pentru prestarea serviciului de colectare a deseurilor municipale se emite cel mai tarziu pana la data de 15 a lunii urmatoare celei in care prestaţia a fost efectuata. Utilizatorii sunt obligati să achite facturile reprezentand contravaloarea serviciului de care au beneficiat, în termenul de scadenta de 15 zile de la data primirii facturii; data emiterii facturii, data predarii facturii, in cazul în care este transmisa prin delegat, şi data scadentei se inscriu pe factura.   ");

            doc.Add(t1);
            Paragraph t2 = new Paragraph(" (2) Neachitarea facturii în termen de 30 de zile de la data scadentei atrage penalitati de întarziere, după cum urmează:   ");

            doc.Add(t2);
            Paragraph t3 = new Paragraph("a) penalitatile sunt egale cu nivelul dobanzii datorate pentru neplata la termen a obligatiilor bugetare, stabilite conform reglementarilor legale în vigoare;   ");

            doc.Add(t3);
            Paragraph t4 = new Paragraph(" b) penalitatile se datoreaza incepand cu prima zi dupa data scadentei;  ");

            doc.Add(t4);
            Paragraph t5 = new Paragraph(" c) valoarea totala a penalitatilor nu poate depasi cuantumul debitului si se constituie venit al operatorului.   ");

            doc.Add(t5);
            Paragraph t6 = new Paragraph(" (3) Nerespectarea de catre utilizatori a conditiilor calitative şi cantitative de depozitare, stabilite prin reglementarile legale in vigoare, conduce la plata unor penalitati şi despqgubiri pentru daunele provocate.   ");

            doc.Add(t6);
            Paragraph t7 = new Paragraph("        Art.15. -  Utilizatorul poate efectua plata serviciilor prestate prin următoarele modalitati:  ");

            doc.Add(t7);
            Paragraph t8 = new Paragraph("a) in numerar la casieria operatorului;   ");

            doc.Add(t8);
            Paragraph t9 = new Paragraph("b) cu fila CEC;  ");

            doc.Add(t9);
            Paragraph t10 = new Paragraph("c) cu ordin de plata; ");

            doc.Add(t10);
            Paragraph t11 = new Paragraph("d) prin internet;  ");

            doc.Add(t11);
            Paragraph t12 = new Paragraph("e) alte instrumente de plata convenite de parti. ");

            doc.Add(t12);
            Paragraph t13 = new Paragraph("Art.16. -  În functie de modalitatea de plata, aceasta se considera efectuata, dupa caz, la una dintre următoarele date:   ");

            doc.Add(t13);
            Paragraph t14 = new Paragraph("a) data certificarii platii de catre unitatea bancara a utilizatorului pentru ordinele de plata;   ");

            doc.Add(t14);
            Paragraph t15 = new Paragraph("b) data certificata de operator pentru filele CEC sau celelalte instrumente de plata legale;   ");

            doc.Add(t15);
            Paragraph t16 = new Paragraph("c) data inscrisa pe chitanta emisa de casieria operatorului.   ");

            doc.Add(t16);
            Paragraph t17 = new Paragraph("        Art.17. -  În cazul in care pe documentul de plata nu se mentioneaza obiectul platii, se considera achitate facturile in ordine cronologica.  ");

            doc.Add(t17);
            Paragraph t18 = new Paragraph("        Art.18. - Facturile si documentele de plata se transmit de operator la adresa, str. " + Strada.Text + ", nr. " + NumarStrada.Text + ", bl. " + Bloc.Text + ", sc. " + Scara.Text + ", etj. " + etaj.Text + ",ap " + Ap.Text + ", localitatea " + Oras.Text + ", jud. " + judet.Text);

            doc.Add(t18);
            Paragraph t19 = new Paragraph("                                                                  " + "CAPITOLUL VII");
            t19.Font.SetStyle(1);
            doc.Add(t19);
            Paragraph t20 = new Paragraph("                                                              " + "Raspunderea contractuala  ");
            doc.Add(t20);
            Paragraph y1 = new Paragraph("        Art.19. -  (1) Pentru neexecutarea in tot sau in parte a obligatiilor contractuale prevazute in prezentul contract, partile raspund conform prevederilor Codului civil, ale Codului comercial şi ale celorlalte acte normative in vigoare.  ");
            doc.Add(y1);
            Paragraph y2 = new Paragraph("(2) Partile contractante pot include si daune-interese pentru neexecutarea totala sau partiala a contractului sub forma daunelor moratorii ori compensatorii.   ");
            doc.Add(y2);
            Paragraph y3 = new Paragraph("(3) Reluarea prestarii serviciului se va face în termen de maximum 3 zile de la efectuarea platii.   ");
            doc.Add(y3);
            Paragraph y4 = new Paragraph("(4) Refuzul total sau partial al utilizatorului de a plati o factură emisa de operator va fi comunicat acestuia în scris, în termen de 10 zile de la data primirii facturii.  ");
            doc.Add(y4);
            Paragraph y5 = new Paragraph("                                                                  " + "CAPITOLUL VIII");
            y5.Font.SetStyle(1);
            doc.Add(y5);
            Paragraph y6 = new Paragraph("                                                                    " + "Forta majora   ");
            doc.Add(y6);
            Paragraph y7 = new Paragraph("       Art.20. -  (1) Niciuna dintre partile contractante nu raspunde de neexecutarea la termen sau de executarea în mod necorespunzator, total ori partial, a oricarei obligatii care ii revine in baza prezentului contract, daca neexecutarea sau executarea necorespunzatoare a obligatiei respective a fost cauzata de forta majora.   ");
            doc.Add(y7);
            Paragraph y8 = new Paragraph("(2) Partea care invocz forta majora este obligata sa notifice în termen de 5 zile celeilalte parţi producerea evenimentului si sa ia toate masurile în vederea limitarii consecintelor acestuia.  ");
            doc.Add(y8);
            Paragraph y9 = new Paragraph("(3) Daca în termen de 30 de zile de la producere evenimentului respectiv nu înceteaza, părtile au dreptul sa notifice încetarea de plin drept a prezentului contract, fara ca vreuna dintre parti sa pretinda daune-interese.  ");
            doc.Add(y9);
            Paragraph y10 = new Paragraph("                                                                  " + "CAPITOLUL IX");
            y10.Font.SetStyle(1);
            doc.Add(y10);
            Paragraph y11 = new Paragraph("                                                                    " + "Litigii  ");
            doc.Add(y11);
            Paragraph y12 = new Paragraph("      Art.21. -  Partile convin ca toate neintelegerile privind validitatea prezentului contract sau rezultate din interpretarea, executarea ori incetarea acestuia sa fie rezolvate pe cale amiabila de reprezentantii lor.  ");
            doc.Add(y12);
            Paragraph y13 = new Paragraph("      Art.22. - In cazul in care nu este posibila rezolvarea litigiilor pe cale amiabila, partile se pot adresa instantelor judecatoresti romane competente.   ");
            doc.Add(y13);
            Paragraph y14 = new Paragraph("                                                                  " + "CAPITOLUL X");
            y14.Font.SetStyle(1);
            doc.Add(y14);
            Paragraph y15 = new Paragraph("                                                                " + "Protectia datelor");
            doc.Add(y15);
            Paragraph y16 = new Paragraph("      Art.23. - Prevederi generale ");
            doc.Add(y16);
            Paragraph y17 = new Paragraph("(1) Fara a aduce atingere niciunei alte clauze din prezentul document, legile nationale privind protectia datelor si Regulamentul General privind Protectia Datelor (GDPR) UE 2016/679 (de la data aplicarii sale, respectiv 25 mai 2018), se vor aplica conform prevederilor lor. Fiecare parte va utiliza, si se va asigura ca subcontractantii sai respectivi utilizeaza, toate datele cu caracter personal ale partii care divulga datele sau ale tertelor parti care divulga datele exclusiv in scopul indeplinirii obiectului Contractului. Partea care divulga datele confirma ca este autorizata sa furnizeze acele date cu caracter personal partii care le primeste.");
            doc.Add(y17);
            Paragraph y18 = new Paragraph("Art.24. - Obligatii de informare in baza GDPR ");
            doc.Add(y18);
            Paragraph y19 = new Paragraph("(1)  Pentru a asigura respectarea obligatiilor de informare din cadrul GDPR, fiecare parte (denumita in continuare „Partea Operator”) va intocmi propria sa nota de informare cu privire la prelucrarea datelor cu caracter personal si o va furniza celeilalte parti (denumita in continuare „Cealalta Parte”). La primirea notei de informare din partea Partii Operator, Cealalta Parte se angajeaza sa comunice aceasta nota de informare tuturor persoanelor vizate din sfera de influenta a Celeilalte Parti (i.e. angajatilor, reprezentantilor si / sau altor persoane implicate de Cealalta Parte) in masura in care datele lor cu caracter personal sunt vizate de obiectul Contractului (denumite in continuare „Persoane Vizate Relevante”). Cealalta Parte va comunica nota de informare pe seama Partii Operator si, la cererea Partii Operator, va furniza dovada ca a comunicat nota de informare Persoanelor Vizate Relevante.");
            doc.Add(y19);
            Paragraph y20 = new Paragraph("     Art.25. Obligatiile imputernicitilor pentru prelucrarea de date cu caracter personal ");
            doc.Add(y20);
            Paragraph u1 = new Paragraph("1)  In cazul in care una dintre parti actioneaza ca imputernicit prelucrand date cu caracter personal in conformitate cu legile aplicabile privind protectia datelor, partile vor incheia un acord de prelucrare a datelor (in conformitate cu cerintele legale ale Art.28 GDPR sau echivalentul acestora) pentru a asigura conformitatea legala cu privire la aceasta prelucrare de date. In cazul in care, in timpul executarii Contractului,  partea care primeste date cu caracter personal trebuie sa le transfere unor terte parti, partea care le primeste va incheia acorduri de prelucrare a datelor avand un continut practic identic cu acordul incheiat intre parti, in conformitate cu si in masura ceruta de prezenta clauza. La finalizarea Contractului, partea care a primit date cu caracter personal, la cererea scrisa a partii care le-a divulgat (actionand in mod rezonabil), va returna partii care le-a divulgat toate datele cu caracter personal primite, precum si rezultatele prelucrarii acestor date si va sterge toate copiile acestora, cu exceptia situatiei in care unele date vor fi pastrate din cauza existentei unor obligatii legale de pastrare. In timpul executarii Contractului si pe durata oricarei perioade de pastrare suplimentare aplicabile, partea care primeste date va: (i) proteja datele cu caracter personal ale partii care le divulga prin masuri de securitate de conforme cu stadiul actual de dezvoltare și va (ii) restricționa accesul la date doar pentru personalul instruit care se angajeaza sa respecte obligatiile de confidentialitate corespunzatoare. Partea care primeste date nu le va transfera in afara Spatiului Economic European (SEE) si nu va prelucra date cu caracter personal din afara Spatiului Economic European (SEE) fara a se asigura în prealabil ca orice primitor sau subcontractant incheie si respecta Clauzele Contractuale Standard (sau orice alta clauza sau acord similar care poate fi aprobat la diferite intervale de timp de catre Comisia Europeana). Toate obligatiile prevazute in aceasta clauza vor ramane in vigoare si dupa finalizarea sau incheierea Contractului.");
            doc.Add(u1);
            Paragraph u2 = new Paragraph("                                                                  " + "CAPITOLUL XI");
            u2.Font.SetStyle(1);
            doc.Add(u2);
            Paragraph u3 = new Paragraph("                                                                " + "Dispozitii finale");
            doc.Add(u3);
            Paragraph u4 = new Paragraph("      Art.26. - In toate problemele care nu sunt prevazute in prezentul contract partile se supun prevederilor legislatiei specifice in vigoare, ale Codului civil, Codului comercial si ale altor acte normative incidente.  ");
            doc.Add(u4);
            Paragraph u5 = new Paragraph("      Art.27. - Prezentul contract se poate modifica cu acordul partilor, prin acte aditionale.  ");
            doc.Add(u5);
            Paragraph u6 = new Paragraph("      Art.28. - Prezentul contract a fost incheiat in doua exemplare azi" + Data.Text + ", cate unul pentru fiecare parte, si intra în vigoare la data de " + Vigoare.Text + ". ");
            doc.Add(u6);
            Paragraph u7 = new Paragraph("                                                                                                                             ");
            doc.Add(u7);
            Paragraph ui = new Paragraph("                Prestatator,                                                                                   Utilizator,  ");
            doc.Add(ui);
            Paragraph u8 = new Paragraph(NumeSocietate1.Text + "                                                                        " + NumeSocietate.Text);
            doc.Add(u8);
            Paragraph u9 = new Paragraph("                Sef Serviciu,                           Sef birou contabilitate                     ADMINISTRATOR,  ");
            doc.Add(u9);
            Paragraph u10 = new Paragraph("            ing. Jitaru Augustin 	                      ec. Cristina Mihaes	                         STROE GABRIEL");
            doc.Add(u10);
            Paragraph u11 = new Paragraph("                                                                                                                                              ");
            doc.Add(u11);
            Paragraph u12 = new Paragraph("                                                                                                                                              ");
            doc.Add(u12);
            Paragraph u13 = new Paragraph("                                                                      " + "Cons.jrd.");
            doc.Add(u13);
            Paragraph u14 = new Paragraph("                                                              " + "Tibuschi Stefan-Augustin");
            doc.Add(u14);
            doc.Close();

            MessageBox.Show("Pdf creat cu succes");
        }

    }
}
