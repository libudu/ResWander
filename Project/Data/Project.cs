using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Data
{
    public class Project
    {
        public HTMLData HTMLData { get; set; }
        public URLData URLData { get; set; }
        public ImgInputData ImgInputData { get; set; }
        public TextInputData TextInputData { get; set; }
        public ImgResourcesContainer ImgResourcesContainer { get; set; }

        public Project()
        {
            HTMLData = new HTMLData();
            URLData = new URLData();
            ImgResourcesContainer = new ImgResourcesContainer();
            TextInputData = new TextInputData();
            ImgInputData = new ImgInputData();
        }
    }
}
