﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public partial class Albums
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }

        public virtual Artists Artist { get; set; }
        public virtual Genres Genre { get; set; }
    }
}