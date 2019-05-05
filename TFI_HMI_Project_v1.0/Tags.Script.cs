//--------------------------------------------------------------
// Press F1 to get help about using script.
// To access an object that is not located in the current class, start the call with Globals.
// When using events and timers be cautious not to generate memoryleaks,
// please see the help for more information.
//---------------------------------------------------------------

namespace Neo.ApplicationFramework.Generated
{
    using System.Windows.Forms;
    using System;
    using System.Drawing;
    using Neo.ApplicationFramework.Tools;
    using Neo.ApplicationFramework.Common.Graphics.Logic;
    using Neo.ApplicationFramework.Controls;
    using Neo.ApplicationFramework.Interfaces;
    
    
    public partial class Tags
    {
		public void devirHesabi(){
		
			double motor_rpm=0;
			
			float reduktor_orani=10.0f;
			float tambur_capi=200;
			
			float devir_bolu_mm=10;
			
			reduktor_orani=Globals.Tags.Motor_Reduktor_Oranı.Value;
			tambur_capi=Globals.Tags.Tambur_Capi.Value;
			devir_bolu_mm=Globals.Tags.Devir_Bolu_Metre.Value*100*100;
			
				
			if(tambur_capi>0){
				motor_rpm= ((devir_bolu_mm*reduktor_orani)/(tambur_capi*Math.PI));
			}
			
			Globals.Tags.Hiz_Rpm.Value=motor_rpm;
		
		}
		
		void Devir_Bolu_Metre_ValueChange(System.Object sender, Core.Api.DataSource.ValueChangedEventArgs e)
		{
			devirHesabi();
		}
		
		void Motor_Reduktor_Oranı_ValueChange(System.Object sender, Core.Api.DataSource.ValueChangedEventArgs e)
		{
			devirHesabi();
		}
		
		void Tambur_Capi_ValueChange(System.Object sender, Core.Api.DataSource.ValueChangedEventArgs e)
		{
			devirHesabi();
		}
		
		void KATLAMA_SAYISI_ValueChange(System.Object sender, Core.Api.DataSource.ValueChangedEventArgs e)
		{
			
			int katlama_sayisi=KATLAMA_SAYISI.Value;
			if(katlama_sayisi>0){
				float boy=OLculen_Boy.Value/katlama_sayisi;
				Katlama_Boyu.Value=(int) boy;
			}
		}
		
		void OLculen_Boy_ValueChange(System.Object sender, Core.Api.DataSource.ValueChangedEventArgs e)
		{
			if(KATLAMA_YAPILIYOR.Value==0){
				int katlama_sayisi=KATLAMA_SAYISI.Value;
				if(katlama_sayisi>0){
					float boy=OLculen_Boy.Value/katlama_sayisi;
					Katlama_Boyu.Value=(int) boy;
				}
			}
		}
		int onceki=0;
		void KATLAMA_YAPILIYOR_ValueChange(System.Object sender, Core.Api.DataSource.ValueChangedEventArgs e)
		{
			if(KATLAMA_YAPILIYOR.Value==0&&onceki==1){
				int katlama_sayisi=KATLAMA_SAYISI.Value;
				if(katlama_sayisi>0){
					float boy=OLculen_Boy.Value/katlama_sayisi;
					Katlama_Boyu.Value=(int) boy;
				}
			}
			onceki=KATLAMA_YAPILIYOR.Value;
		}
		
    }
}
