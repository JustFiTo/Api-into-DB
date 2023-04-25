using System;
using System.Collections.Generic;
using System.Text;

namespace APItoDB
{
    class ApiAnbindung
    {
        private String url;
        private String requestType;
        private String input;

        public ApiAnbindung(String url, String requestType, String input)
        {
            this.url = url;
            this.requestType = requestType;
            this.input = input;
        }
    }
}
