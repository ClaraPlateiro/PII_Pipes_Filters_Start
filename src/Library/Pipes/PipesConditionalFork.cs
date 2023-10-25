using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using Ucu.Poo.Cognitive;
using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeConditionalFork: IPipe
    {
        private FilterConditional filterConditional;
        private IPipe hasFacePipe;
        private IPipe noFacePipe;

        public PipeConditionalFork(FilterConditional filterConditional1, IPipe hasFacePipe1, IPipe noFacePipe1)
        {
            this.filterConditional = filterConditional1;
            this.hasFacePipe = hasFacePipe1;
            this.noFacePipe = noFacePipe1;
        }

        public IPicture Send(IPicture picture)
        {
            filterConditional.Filter(picture);
            bool face = filterConditional.face;

            if (face)
            {
                return hasFacePipe.Send(picture);
            }
            else
            {
                return noFacePipe.Send(picture);
            }
        }
    }
}