﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApi.DTO.LineModel
{
    public class LineResponseModel
    {
        public Guid Id { get; set; }
        public Guid NotebookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
