using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
	public class OperationClaim:IEntity
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

	}
}

