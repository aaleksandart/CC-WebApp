﻿using CC.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities
{
    public class RentDataEntity : IRentDataEntity
    {
        public RentDataEntity()
        {
        }

        public RentDataEntity(int toolId, int userId, DateTime rentStart, DateTime rentEnd)
        {
            ToolId = toolId;
            UserId = userId;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }

        public RentDataEntity(ToolEntity? tool, UserEntity? user, DateTime rentStart, DateTime rentEnd)
        {
            Tool = tool;
            User = user;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }

        public RentDataEntity(int toolId, ToolEntity? tool, int userId, UserEntity? user, DateTime rentStart, DateTime rentEnd)
        {
            ToolId = toolId;
            Tool = tool;
            UserId = userId;
            User = user;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }

        [Key]
        public int RentDataId { get; set; }

        [ForeignKey("Tool")]
        public int ToolId { get; set; }
        public ToolEntity? Tool { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity? User { get; set; }

        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
    }
}
