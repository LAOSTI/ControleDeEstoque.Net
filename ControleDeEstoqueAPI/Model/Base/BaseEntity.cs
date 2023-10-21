﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ControleDeEstoqueAPI.Model.Base
{
	public class BaseEntity
	{
		[Key]
		[Column("Id")]
		public long Id { get; set; }
	}
}
