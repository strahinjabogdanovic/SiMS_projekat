   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjekatSIMSProjekatSIMS  5   	       ProjekatSIMS.Anamneza   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProjekatSIMS     5   	     � Title$  Anamneza��5   	   $	��450��6   $	��800��6'   
����ح�.��5	      � 
�������.+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Anamneze��5
         SelectionMode$ Single=�5         AutoGenerateColumns .  $
��Left=�6F   $	��139��5      $��
137,40,0,0q�6    $	��Top=�64   $	��501��6L   ��5
   %   ��  �� Path$ Izvopr� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Vrsta izvestaja��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� $ vrsta�  5      $ Datum izvestaja��6%    6>   �� $ datum�  5      $ Odeljenje na prijemu��6%    6C   �� $ 	odeljenje�  5      $ Nalaz i misljenje��6%    6@   �� $ nalaz�  5      $ Kontrola��6%    67   �� $ kontrola�  5      $ Terapija��6%    67   �� $ terapija�5      �� 5   
   $��Izmeni��6   $
��Left=�6"   $��46��6=   $��816,110,0,0q�6I   $	��Top=�6^   $	��156��6v   
��� ���
��� �����6�   �� *Izmeni+6�   �� 5   
   -   5        	 ��Name$	 tjmbg��5   +   $
��Left=�6:   $��
89,508,0,0q�6U   $
��Wrap=�6i   $	��Top=�6~   $��20��6�   $	��131��6�   $y�Hidden=�6�   ��6   �� *TJmbg+6�   �� 5   
   -   5        
 ��Name$
 tooltip��5      ���	#FFF4F4F5$
��Left=�66   $��55��6Q   $��
792,50,0,0q�6]   
���   �$	��Top=�6�   $	��128��6�    �� RadiusX$ 20��6�    �� RadiusY$ 20��6�   y�6�   �� *	Tooltip+�� 5   
   -   5         ��Name$ 
labtooltip��5      $?��9Prvo izmeni direktno 
   u tabeli i onda 
      me klikni��6$   $
��Left=�6p   $��
792,50,0,0q�6�   $	��Top=�6�   $��55��6�   $	��128��6�   y�6�   �� *	Tooltip+�� 5   
   $��Unesite novu belesku:��6   $
��Left=�60   $��
24,201,0,0q�6K   $	��Top=�6_   $��20(�6w   �� 5   
   -   5         ��Name$ tb��5      $
��Left=�6   $	��113��6:   $��240,201,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��475��6�   $��20(�6�    J� RenderTransformOrigin$ 0.494,0.287&�6�   �� 5   
   -   5        $��Stare beleske��5      $
��Left=�6)   $��302,354,0,0q�6D   $	��Top=�6Y   $	��154��6q   $��20(�6}   $��37��6�   6�   �� 5   
   -   5        $��Potvrdi��5      $
��Left=�6#   $��521,354,0,0q�6>   $	��Top=�6S   $	��151��6k   $��20(�6w   $��37��6�   6�   �� 5   
   -   5        $��	Podsetnik��5      $
��Left=�6%   $��
89,354,0,0q�6@   $	��Top=�6T   $	��146��6l   $��37��6x   $��20(�6�   6�   5       5!      