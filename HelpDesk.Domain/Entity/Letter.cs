﻿using HelpDesk.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entity
{
	public class Letter
	{
        public int Id{ get; set; }
		public Status Status { get; set; }
		public string Title { get; set; }
		public Enum.Action Name { get; set; }
	}
}
