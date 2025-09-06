namespace Template01.Models.Shared
{
    public class Head
    {
        /// <summary>
        /// Conteúdo da tag title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Nome utilizado nas aplicações mobiles
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// Mesa Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Meta Key Words
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// Meta Authors
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Imagem SRC do head
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// Favicon da página
        /// </summary>
        public string Favicon { get; set; }

        public string TouchIcon { get; set; }
        public string TouchIcon70 { get; set; }
        public string TouchIcon72 { get; set; }
        public string TouchIcon76 { get; set; }
        public string TouchIcon114 { get; set; }
        public string TouchIcon120 { get; set; }
        public string TouchIcon144 { get; set; }
        public string TouchIcon150 { get; set; }
        public string TouchIcon152 { get; set; }
        public string TouchIcon310 { get; set; }

        /// <summary>
        /// Tempo de atualização da página. Se igual a ZERO não é utilizado
        /// </summary>
        public int RefreshTime { get; set; }

    }
}