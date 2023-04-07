using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Equipamentos
{
    public class EquipamentoSonoro : Equipamento
    {
        public short Volume { get; set; }

        public static EquipamentoSonoro CriarEquipamentoComVolume(short volume)
        {
            return new EquipamentoSonoro(volume);
        }
        EquipamentoSonoro(short volume)
        {
            if (volume >= 10)
                this.Volume = 10;
            else if (volume <= 0)
                this.Volume = 0;
            else
                this.Volume = volume;
        }
        public bool Stereo { get; set; }
        public void Mono()
        {
            this.Stereo = false;
        }
        public void TurnStereo()
        {
            this.Stereo = true;
        }
        public override void TurnOn()
        {
            base.TurnOn();
            this.Volume = 5;
        }

        public void Force()
        {
            //  base.TurnOff();
        }
    }
}
