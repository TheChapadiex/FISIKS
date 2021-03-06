﻿using FisiksAppWeb.Entities;
using FisiksAppWeb.Util;
using FisykDAL.Util;
using Oracle.DataAccess.Client;

namespace FisykDAL.Parsers
{
    internal class DpAgenda : DtoParserSqlOracle
    {
        private int _ordAgeId;
        private int _ordAgeHoraDesde;
        private int _ordAgeHoraHasta;
        private int _ordAgeProId;
        private int _ordAgeDiaId;

        internal override void PopulateOrdinals(OracleDataReader reader)
        {
            _ordAgeId = reader.GetOrdinal("ageId");
            _ordAgeHoraDesde = reader.GetOrdinal("ageHoraDesde");
            _ordAgeHoraHasta = reader.GetOrdinal("ageHoraHasta");
            _ordAgeProId = reader.GetOrdinal("age_proId");
            _ordAgeDiaId = reader.GetOrdinal("age_diaId");
        }

        internal override DtoBase PopulateDto(OracleDataReader reader)
        {
            var agenda = new AgendaDto();
            // 
            if (!reader.IsDBNull(_ordAgeId)) { agenda.AgeId = reader.GetInt32(_ordAgeId); }
            // 
            if (!reader.IsDBNull(_ordAgeHoraDesde)) { agenda.AgeHoraDesde = reader.GetDateTime(_ordAgeHoraDesde); }
            // 
            if (!reader.IsDBNull(_ordAgeHoraHasta)) { agenda.AgeHoraHasta = reader.GetDateTime(_ordAgeHoraHasta); }
            // 
            if (!reader.IsDBNull(_ordAgeProId)) { agenda.AgeProId = reader.GetInt32(_ordAgeProId); }
            // 
            if (!reader.IsDBNull(_ordAgeDiaId)) { agenda.AgeDiaId = reader.GetInt32(_ordAgeDiaId); }
            // IsNew
            agenda.IsNew = false;

            return agenda;
        }
    }
}

