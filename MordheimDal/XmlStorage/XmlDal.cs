using DomainModel;
using DomainModel.Warbands;
using MordheimDal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimDal.XmlStorage
{
    internal class XmlDal : IDAL
    {
        public IWarBand Load()
        {
            throw new NotImplementedException();
        }

        public void Save(IWarbandRoster roster)
        {
            XmlHeadNode xmlHeadNode = new XmlHeadNode();

            xmlHeadNode.WarbandRoster.Name = roster.Name;

            xmlHeadNode.WarbandRoster.Warband = roster.WarBand.WarBandName;
        }
    }
}