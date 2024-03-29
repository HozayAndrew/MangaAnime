﻿using MangaAPI.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangaAPI
{
    public class MangaSite
    {
        public MangaSites Site { get; }
        internal string BaseUrl { get; private set; }
        internal string MangaListUrl { get; private set; }
        internal IParser Parser { get; private set; }

        public MangaSite(MangaSites site)
        {
            Site = site;
            ChooseUrl();
            ChooseListUrl();
            ChooseParser();
        }

        private void ChooseUrl()
        {
            switch(Site)
            {
                case MangaSites.ReadManga:
                    BaseUrl = "http://readmanga.me";
                    break;
                case MangaSites.MintManga:
                    BaseUrl = "http://mintmanga.com";
                    break;
            }
        }

        private void ChooseListUrl()
        {
            switch (Site)
            {
                case MangaSites.ReadManga:
                case MangaSites.MintManga:
                    MangaListUrl = BaseUrl + "/list";
                    break;
            }
        }

        private void ChooseParser()
        {
            switch(Site)
            {
                case MangaSites.ReadManga:
                case MangaSites.MintManga:
                    Parser = new ReadMeMangaParser();
                    break;
            }
        }
    }

    public enum MangaSites
    {
        ReadManga, 
        MintManga
    }
}
