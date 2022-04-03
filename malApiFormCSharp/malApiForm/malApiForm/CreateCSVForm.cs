﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace malApiForm
{
    public partial class CreateCSVForm : Form
    {
        //File da creare con dentro la proprio authKey, sennò usare secret user
        string authKey = File.ReadAllText("..\\..\\..\\..\\..\\..\\mySecretKey.txt");


        public CreateCSVForm()
        {
            InitializeComponent();

            chooseListComboBox.SelectedIndex = 0;
        }

        private void csvButton_Click(object sender, EventArgs e)
        {
            //Controllo prima della richiesta del nome utente inserito
            if (searchUserTextBox.Text.TrimStart().TrimEnd().Length > 0)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult dialogResultFolderBrowser = fbd.ShowDialog();
                string path = fbd.SelectedPath.TrimStart().TrimEnd();
                if (dialogResultFolderBrowser == DialogResult.OK)
                {
                    errorLabel.Visible = true;
                    errorLabel.ForeColor = Color.White;
                    errorLabel.Text = "Wait...";
                    errorLabel.Refresh();

                    //Scelta effettuata dall'array sopra
                    string selectedAnimeOrManga = chooseListComboBox.Text.ToLower();

                    //Chiamata Api
                    string apiUrl = "https://api.myanimelist.net/v2/users/" + searchUserTextBox.Text + "/" + selectedAnimeOrManga + "list?fields=list_status&limit=1000";

                    //Stringa Json dalla chiamata Api
                    string jsonString = "";

                    //Chiamata Api
                    Uri address = new Uri(apiUrl);
                    HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                    request.Method = "GET";
                    request.ContentType = "text/json";
                    request.Headers.Add("Authorization", "Bearer " + authKey);

                    try
                    {
                        //Salvataggio su "jsonString" della risposta
                        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                        {
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            jsonString = reader.ReadToEnd();
                        }

                        //Conversione da Json String a Json
                        var allJsonContent = JObject.Parse(jsonString);

                        //Console.WriteLine(allJsonContent["data"]);

                        //Lista di Dict in cui verrà salvata la risposta come vogliamo (cambia in base a selectedAnimeOrManga)
                        List<Dictionary<string, object>> resList = new List<Dictionary<string, object>>();

                        //Se ha richiesto una lista di Manga
                        if (selectedAnimeOrManga.Equals("manga"))
                        {

                            /*
                            * RISPOSTA (DATA):
                            * 
                            * 
                            {
                               "node": {
                                 "id": 1695,
                                 "title": "Adolf ni Tsugu",
                                 "main_picture": {
                                   "medium": "https://api-cdn.myanimelist.net/images/manga/2/1788.jpg",
                                   "large": "https://api-cdn.myanimelist.net/images/manga/2/1788l.jpg"
                                 }
                               },
                               "list_status": {
                                 "status": "completed",
                                 "is_rereading": false,
                                 "num_volumes_read": 4,
                                 "num_chapters_read": 36,
                                 "score": 9,
                                 "updated_at": "2020-10-04T01:16:45+02:00"
                               }
                             }

                            * 
                            */

                            //mangaList dal Json
                            resList = allJsonContent["data"]
                                .Where(s => int.Parse(s["list_status"]["num_chapters_read"].ToString()) > 0)
                                .Select(s => new Dictionary<string, object> {
                            { "title", s["node"]["title"].ToString().Replace(";", "") },
                            { "id", int.Parse(s["node"]["id"].ToString())},
                            { "score", int.Parse(s["list_status"]["score"].ToString()) != 0 ? s["list_status"]["score"].ToString() : "None"},
                            { "reading_status", s["list_status"]["status"].ToString().Replace(";", "").Replace(",", "") },
                            { "chapters_read", int.Parse(s["list_status"]["num_chapters_read"].ToString())},
                            { "volumes_read", int.Parse(s["list_status"]["num_volumes_read"].ToString())}
                                })
                                .ToList();

                            Console.WriteLine("\nManga Letti:");

                            //Output mangaList dove il campo "score" è > 0
                            resList.Where(s => !s["score"].Equals("None"))
                                .OrderByDescending(s => int.Parse(s["score"].ToString()))
                                .ThenBy(m => m["title"])
                                .ToList()
                                .ForEach(s => Console.WriteLine("\t" + s["title"] + " -> " + s["score"] + " --------------- " + s["reading_status"]));

                            //Output mangaList dove il campo "score" è == 0
                            resList.Where(s => s["score"].Equals("None"))
                                .OrderByDescending(s => s["title"])
                                .ThenBy(m => m["reading_status"])
                                .ToList()
                                .ForEach(s => Console.WriteLine("\t" + s["title"] + " -> " + s["score"] + " --------------- " + s["reading_status"]));
                        }
                        //Se ha richiesto una lista di Anime
                        else if (selectedAnimeOrManga.Equals("anime"))
                        {

                            /*
                            * RISPOSTA (DATA):
                            * 
                            * 
                            "node": {
                               "id": 31646,
                               "title": "3-gatsu no Lion",
                               "main_picture": {
                                   "medium": "https://myanimelist.cdn-dena.com/images/anime/12/82901.jpg",
                                   "large": "https://myanimelist.cdn-dena.com/images/anime/12/82901l.jpg"
                               }
                            },
                            "list_status": {
                               "status": "plan_to_watch",
                               "score": 0,
                               "num_episodes_watched": 0,
                               "is_rewatching": false,
                               "updated_at": "2017-11-11T19:52:16+00:00"
                            }

                            * 
                            */

                            //animeList dal Json
                            resList = allJsonContent["data"]
                                .Where(s => int.Parse(s["list_status"]["num_episodes_watched"].ToString()) > 0)
                                .Select(s => new Dictionary<string, object> {
                            { "title", s["node"]["title"].ToString().Replace(";", "").Replace(",", "") },
                            { "id", int.Parse(s["node"]["id"].ToString())},
                            { "score", int.Parse(s["list_status"]["score"].ToString()) != 0 ? s["list_status"]["score"].ToString() : "None"},
                            { "watched_status", s["list_status"]["status"].ToString().Replace(";", "") },
                            { "watched_episodes", int.Parse(s["list_status"]["num_episodes_watched"].ToString())}
                                })
                                .ToList();

                            Console.WriteLine("\nAnime Visti:");

                            //Output animeList dove il campo "score" è > 0
                            resList.Where(s => !s["score"].Equals("None"))
                                .OrderByDescending(s => int.Parse(s["score"].ToString()))
                                .ThenBy(m => m["title"])
                                .ToList()
                                .ForEach(s => Console.WriteLine("\t" + s["title"] + " -> " + s["score"] + " --------------- " + s["watched_status"]));

                            //Output animeList dove il campo "score" è > 0
                            resList.Where(s => s["score"].Equals("None"))
                                .OrderByDescending(s => s["title"])
                                .ThenBy(m => m["watched_status"])
                                .ToList()
                                .ForEach(s => Console.WriteLine("\t" + s["title"] + " -> " + s["score"] + " --------------- " + s["watched_status"]));
                        }

                        //Creazione CSV
                        bool checkCSVExport = exportCSV(selectedAnimeOrManga, path, resList);

                        if(checkCSVExport == true)
                        {
                            errorLabel.Visible = true;
                            errorLabel.ForeColor = Color.White;
                            errorLabel.Text = "File CSV creato";
                        }
                        else
                        {
                            errorLabel.Visible = true;
                            errorLabel.ForeColor = Color.FromArgb(255, 30, 50);
                            errorLabel.Text = $"ERRORE! File CSV Non Creato";
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine($"\n{err.StackTrace}\n{err.Message}");

                        File.WriteAllText($"..\\..\\..\\..\\..\\..\\Error_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}.txt",
                            $"[{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}]\n\n{err.StackTrace}\n\n{err.Message}");

                        errorLabel.Visible = true;
                        errorLabel.ForeColor = Color.FromArgb(255, 30, 50);
                        errorLabel.Text = $"ERRORE! Controllare il file 'Error_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}.txt'";
                    }
                    finally
                    {
                        Console.WriteLine("\nFine");
                    }
                }
                else
                {
                    errorLabel.Visible = false;
                }
            }
            else
            {
                Console.WriteLine("Nome Utente inserito non valido (controllo sul Form)");
                errorLabel.Visible = true;
                errorLabel.ForeColor = Color.FromArgb(255, 30, 50);
                errorLabel.Text = $"ERRORE! Nome Utente inserito non valido";
            }
        }

        private bool exportCSV(string selectedAnimeOrManga, string path, List<Dictionary<string, object>> resList)
        {
            //Lista in cui verranno salvati gli elementi riordinati da resList
            List<Dictionary<string, object>> newOrderList = new List<Dictionary<string, object>>();

            //ordinamento quandio Score è > 0 (Score != None)
            newOrderList = resList.Where(s => !s["score"].Equals("None"))
                        .OrderByDescending(s => int.Parse(s["score"].ToString()))
                        .ThenBy(m => m["title"])
                        .ToList();

            //Se ci sono elementi con voti > 0
            if (newOrderList.Count > 0)
            {
                try
                {
                    //Only First Letter ToUpper()
                    selectedAnimeOrManga = selectedAnimeOrManga.Substring(0, 1).ToUpper() + selectedAnimeOrManga.Substring(1).ToLower();

                    //Dove verrà salvato il file
                    string filePath = $"{path}\\MAL_{searchUserTextBox.Text}_{selectedAnimeOrManga}_List_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}.csv";

                    //Variabile in cui viene salvato tutto il testo e successivamente caricato nel Csv
                    var csv = new StringBuilder();
                    File.WriteAllText(filePath, "");

                    //Se ha richiesto una lista di Manga
                    if (selectedAnimeOrManga.ToLower().Equals("manga"))
                    {
                        //Aggiunge i rimanenti elementi, con Score == None
                        newOrderList.AddRange(
                            resList.Where(s => s["score"].Equals("None"))
                                    .OrderByDescending(s => s["title"])
                                    .ThenBy(m => m["reading_status"])
                                    .ToList()
                            );

                        /*
                         * --> STRUTTURA DICT
                         * 
                         * //mangaList dal Json
                            resList = allJsonContent["data"]
                                .Where(s => int.Parse(s["list_status"]["num_chapters_read"].ToString()) > 0)
                                .Select(s => new Dictionary<string, object> {
                                    { "title", s["node"]["title"].ToString() },
                                    { "id", int.Parse(s["node"]["id"].ToString())},
                                    { "score", int.Parse(s["list_status"]["score"].ToString()) != 0 ? s["list_status"]["score"].ToString() : "None"},
                                    { "reading_status", s["list_status"]["status"] },
                                    { "chapters_read", int.Parse(s["list_status"]["num_chapters_read"].ToString())},
                                    { "volumes_read", int.Parse(s["list_status"]["num_volumes_read"].ToString())}
                                })
                                .ToList();
                         * 
                         */

                        //Prima Riga, le Colonne
                        var newLine = string.Format("Title;Id MAL;Score;Status;Chapters Read;Volumes Read");

                        //Aggiunta riga delle Colonne
                        csv.Append(newLine + "\n");

                        //Aggiunte le altre righe 1 alla volta
                        foreach (var item in newOrderList)
                        {
                            newLine = $"{item["title"]};{item["id"]};{item["score"]};{item["reading_status"]};{item["chapters_read"]};{item["volumes_read"]}";

                            csv.Append(newLine + "\n");
                        }

                        //Scrittura su File del testo
                        File.WriteAllText(filePath, csv.ToString());
                    }
                    //Se ha richiesto una lista di Anime
                    else if (selectedAnimeOrManga.ToLower().Equals("anime"))
                    {

                        //Aggiunge i rimanenti elementi, con Score == None
                        newOrderList.AddRange(
                            resList.Where(s => s["score"].Equals("None"))
                                    .OrderByDescending(s => s["title"])
                                    .ThenBy(m => m["watched_status"])
                                    .ToList()
                            );

                        /*
                         * --> STRUTTURA DICT
                         *  
                         * resList = allJsonContent["data"]
                            .Where(s => int.Parse(s["list_status"]["num_episodes_watched"].ToString()) > 0)
                            .Select(s => new Dictionary<string, object> {
                                { "title", s["node"]["title"].ToString() },
                                { "id", int.Parse(s["node"]["id"].ToString())},
                                { "score", int.Parse(s["list_status"]["score"].ToString()) != 0 ? s["list_status"]["score"].ToString() : "None"},
                                { "watched_status", s["list_status"]["status"] },
                                { "watched_episodes", int.Parse(s["list_status"]["num_episodes_watched"].ToString())}
                            })
                            .ToList();
                         * 
                         */

                        //Prima Riga, le Colonne
                        var newLine = string.Format("Title;Id MAL;Score;Status;Watched Episodes");

                        //Aggiunta riga delle Colonne
                        csv.Append(newLine + "\n");

                        //Aggiunte le altre righe 1 alla volta
                        foreach (var item in newOrderList)
                        {
                            newLine = $"{item["title"]};{item["id"]};{item["score"]};{item["watched_status"]};{item["watched_episodes"]}";

                            csv.Append(newLine + "\n");
                        }

                        File.WriteAllText(filePath, csv.ToString());
                    }

                    Console.WriteLine("\nCreazione del CSV Avvenuta Correttamente");
                    Console.WriteLine($"Nome File CSV Creato: MAL_{searchUserTextBox.Text}_{selectedAnimeOrManga}_List_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}.csv");

                    return true;
                }
                catch (Exception err)
                {

                    Console.WriteLine($"{err.StackTrace}\n{err.Message}");
                }
            }

            return false;
        }

        private void closeAllButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
