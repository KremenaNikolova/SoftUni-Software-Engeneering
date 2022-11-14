using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace P02.Graphic_Editor
{
    public class GraphicEditor 
        //graphicEditor da moje da risuva vichki viodove formi bez da prowerqva ot koi vid e formata
        //v bydeshte shte bydat dobaveni nowi formi, taka che podgotvete systemataa za tozi moment
        //kogato se dobavi nova forma, trqbva samo da se syzdade nov klas za neq bez nishto drugo da se promenq
    {
        public void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}
