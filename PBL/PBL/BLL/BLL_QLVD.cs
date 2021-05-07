﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL.DAL;

namespace PBL.BLL
{
    class BLL_QLVD
    {
        private static BLL_QLVD _Instance;
        public static BLL_QLVD Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLVD();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_QLVD() { }

        public List<LOAIVATDUNG> GetListLoaiVatDung(string s)
        {
            if (s != null)
            {
                return new QLKS().LOAIVATDUNGs.Where(lvd => lvd.TenVatDung == s).ToList();
            }
            return new QLKS().LOAIVATDUNGs.ToList();
        }
        public LOAIVATDUNG FindLoaiVatDung(string s)
        {
            return new QLKS().LOAIVATDUNGs.Find(s);
        }
        public void AddLoaiVatDung(LOAIVATDUNG lvd)
        {
            QLKS db = new QLKS();
            db.LOAIVATDUNGs.Add(lvd);
            db.SaveChanges();
        }
        public void UpdateLoaiVatDung(LOAIVATDUNG lvd)
        {
            QLKS db = new QLKS();
            var lvd1 = db.LOAIVATDUNGs.Find(lvd.VatDungID);
            lvd1.TenVatDung = lvd.TenVatDung;
            lvd1.DonGia = lvd.DonGia;
            lvd1.ThietBiCoDinh = lvd.ThietBiCoDinh;
            db.SaveChanges();
        }
        public void DeleteLoaiVatDung(List<string> l)
        {
            QLKS db = new QLKS();
            foreach(string s in l)
            {
                db.LOAIVATDUNGs.Remove(db.LOAIVATDUNGs.Find(s));
                db.SaveChanges();
            }
        }
    }
}