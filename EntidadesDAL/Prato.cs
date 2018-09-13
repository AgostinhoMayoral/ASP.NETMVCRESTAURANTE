namespace EntidadesDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prato")]
    public partial class Prato
    {
        public int PratoId { get; set; }

      //  [Required(ErrorMessage = "O nome do restaurante � obrigat�rio", AllowEmptyStrings = false)]
        public int? RestauranteId { get; set; }

      //  [Required(ErrorMessage = "O nome do produto � obrigat�rio", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string PratoNome { get; set; }

      //  [Required(ErrorMessage = "Informe o pre�o do produto", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal? PratoPreco { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}
