   M S B A M L   `   `   `  ����G  CProjekatSIMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjekatSIMS.Lekar.ViewProjekatSIMS.Lekar.View  5      8    2ProjekatSIMS.Lekar.View.ZakazivanjeKodSpecijaliste   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ProjekatSIMS.Lekar.View     5        N� Title$   ZakazivanjeKodSpecijaliste��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��473* �6   �� 5      $
��224* �6   �� 5      $
��297* �6   .+�5   
   �� $��Specijalizacija��6   $
��Left=�6*   $��128,200,0,0q�6E   $	��Top=�6Z   $��16(�6r   �� 5   
   -   5         ��Name$ tBlock1��5      $
��Left=�6G   $��320,200,0,0q�6b   $
��Wrap=�6w   $	��Top=�6�   $��33��6�   $	��298��6�   $��2��6�   $��16(�6�   $��Italic$�6�   ��6%   �� *TSpecijalizacija+6�   �� 5   
   $��Izaberite zeljenog lekara��6   $
��Left=�64   $��128,250,0,0q�6O   $	��Top=�6d    J� RenderTransformOrigin$ 0.035,0.615&�6|   $��33��6�   $	��200��6�   $��16(�6�   �� 5   
   -   5         ��Name$ combo��5       �� Text$ Izaberi lekara��6"   $
��Left=�5   �   $��33��6�   $��320,250,0,0q�6�   $	��Top=�6�   $	��298��6�   $��2��6�   
�������
���   �$��16(�6P  $��Italic$�6^   �� SelectedItem 6   ��  �� Path$ Lekari1� �� DisplayMemberPath 6:   �� $ Vrednost���6f   �� $ Lekari�6^  �� 5   
   -   5        	 ��Name$	 Labela��5      $��Slobodni termini��6    $
��Left=�6;   $��128,300,0,0q�6V   $	��Top=�6k   $��30��6�   $	��137��6�   $y�Visible=�6�   $��16(�6�   �� 5   
   -   5        $ 	slobcombo��5      $
��Left=�6'   $��320,300,0,0q�6B   $	��Top=�6W   $	��298��6o   $��33��6{   $y�Visible=�6�   $��2��6�   
�������
���   �$��16(�6�   $��Italic$�6�   �� 5   
   -   5        
 ��Name$
 zakazi��5      $��Zakaži��6!   $
��Left=�62   $��320,425,0,0q�6M   $	��Top=�6b   $	��190��6z   $��30��6�   $y�Visible=�6�   
�������
��� �����6�   �� $ zakazi�6�   �� 5   
   -   5        $
 Nazad��5      $
��🠔��6    $
��Left=�6-   $��	33,33,0,0q�6H   $	��Top=�6\   $��40��6t   $��64��6�   $��30(�6�   $ 0.516,0.533&�6�   
�������
�������
����  ���6�   �� *Nazad+6  �� 5   
   $1��+Zakazivanje termina kod lekara specijaliste��6   $
��Left=�6F   $��
128,64,0,0q�6a   $	��Top=�6u   $��22(�6�   $��2��6�   $��41��6�   $	��437��6�   �� 5   
   $��Vrsta termina��6   $
��Left=�6(   $��128,350,0,0q�6C   $	��Top=�6X   $��16(�6p   �� 5   
   -   5        $ vrsta��5      $
��Left=�6#   $��320,350,0,0q�6>   $	��Top=�6S   $	��298��6k   $��2��6w   $��33��6�   
���   �$��16(�6�   $��Italic$�6�   5      5      