﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YueShanp.Models
{
    public class BaseEntity<T>
    {
        public virtual T Id { get; set; }
        public virtual string Creator { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual string LastEditor { get; set; }
        public virtual DateTime LastEditTime { get; set; }
        public virtual EntityStatus EntityStatus { get; set; }
    }
}