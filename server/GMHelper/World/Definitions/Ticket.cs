/*
          _______ _____  _______ _______ _______ 
         |    ___|     \|    ___|   |   |   |   |
         |    ___|  --  |    ___|       |   |   |
         |_______|_____/|_______|__|_|__|_______| 
     Copyright (C) 2013 EmuDevs <http://www.emudevs.com/>
 
  This program is free software; you can redistribute it and/or modify it
  under the terms of the GNU General Public License as published by the
  Free Software Foundation; either version 2 of the License, or (at your
  option) any later version.
 
  This program is distributed in the hope that it will be useful, but WITHOUT
  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
  FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
  more details.
 
  You should have received a copy of the GNU General Public License along
  with this program. If not, see <http://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;

namespace GMHelper
{
    public enum GMTicketResponse : uint
    {
        GMTICKET_RESPONSE_ALREADY_EXIST = 1,
        GMTICKET_RESPONSE_CREATE_SUCCESS = 2,
        GMTICKET_RESPONSE_CREATE_ERROR = 3,
        GMTICKET_RESPONSE_UPDATE_SUCCESS = 4,
        GMTICKET_RESPONSE_UPDATE_ERROR = 5,
        GMTICKET_RESPONSE_TICKET_DELETED = 9
    };

    public enum GMTicketStatus : byte
    {
        GMTICKET_STATUS_HASTEXT = 6,
        GMTICKET_STATUS_DEFAULT = 10
    };

    public enum GMTicketEscalationStatus : byte
    {
        TICKET_UNASSIGNED = 0,
        TICKET_ASSIGNED = 1,
        TICKET_IN_ESCALATION_QUEUE = 2,
        TICKET_ESCALATED_ASSIGNED = 3
    };

    public enum GMTicketOpenedByGMStatus : byte
    {
        GMTICKET_OPENEDBYGM_STATUS_NOT_OPENED = 0,  // ticket has never been opened by a gm
        GMTICKET_OPENEDBYGM_STATUS_OPENED = 1       // ticket has been opened by a gm
    };

    public class Tickets
    {
        public static List<Ticket> TicketList = new List<Ticket>();
    }

    public class Ticket
    {
        public GMTicketStatus Status;
        public UInt32 Id;
        public string Message;
        public bool HasTicket;
        public float LastModifiedAge;
        public float OldAge;
        public float LastTicketChange;
        public GMTicketEscalationStatus EscalationStatus;
        public GMTicketOpenedByGMStatus OpenedStatus;
    }
}
