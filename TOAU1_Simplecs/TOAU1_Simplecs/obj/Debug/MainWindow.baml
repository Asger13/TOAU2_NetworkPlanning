   M S B A M L   `   `   `  ����I  ETOAU1_Simplecs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TOAU1_SimplecsTOAU1_Simplecs  5   	       TOAU1_Simplecs.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TOAU1_Simplecs     5   	     � Title$  GoodSimpleX��5   	   $��485.764��6   $��324.411��6.    � WindowStartupLocation$ CenterScreen=�6>   .��5	      �  � RowDefinitions 5
      �� 5      $
��auto �6   6)   �� 5      6   .+�5      o� .@�5      m� $��Файл��6   .@�5      m� -   5        $��Новое решение��5      6I   m� 5      -   5         m�Name$
 Save��5      $'��!Сохранить решение��6%   6U   m� 5      -   5        $'��!Загрузить решение��5      6M   �� 5      6   m� 5      -   5        $��
Выход��5      6?   5      m� 5      -   5        $
 Summ��5      $��Расчет��6"   .@�5      m� -   5        $-��'Максимальную прибыль��5      6P   m� 5      -   5        $-��'Минимальные издержки��5      6P   �� 5      6   m� 5      -   5        $	 Rep��5      $��
Отчет��6$   6N   5      5   	   �� 5      -	   5         ��Name$ label��5      $��Продукция��6   $
��Left=�61   $��
107,27,0,0q�6L   $	��Top=�6`    J� RenderTransformOrigin$ 0.132,0.387&�6x   $��21.333(�6�   �� 5      -
   5        $ label1��5      $��ID��6   $
��Left=�6+   $��	10,65,0,0q�6F   $	��Top=�6Y   $��18.667(�6q   �� 5       -   5        $ label2��5       $��Ограничние��6   $
��Left=�63   $��	10,91,0,0q�6N   $	��Top=�6a   $��18.667(�6y   �� 5!      -   5        $ label3��5!      $��Цена��6   $
��Left=�6-   $��
10,122,0,0q�6H   $	��Top=�6\   $��18.667(�6t   �� 5"      -   5        $ label4��5"      $��Компоненты��6   $
��Left=�63   $��
10,153,0,0q�6N   $	��Top=�6b   $��18.667(�6z   �� 5#      -   5         ��Name$ 	textBoxID��5#      $
��Left=�6#   $��23��6>   $��
139,70,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��158��6�   $��16(�6�    �� 
IsReadOnly . 6�   �� 5$      -   5        $ textBoxLimit��5$      $
��Left=�6&   $��23��6A   $��
139,98,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��158��6�   $��16(�6�   �� 5%      -   5        $ textBoxPrice��5%      $
��Left=�6&   $��23��6A   $��139,126,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��158��6�   $��16(�6�   �� 5&      -   5        	 ��Name$	 spLimitComponents��5&      $
��Left=�6.   $��
19,188,0,0q�6I   $	��278��6]   $	��210��6i   $	��Top=�6v   .+�5'      � $��30��6   .+�5(      �� -   5        $ label5��5(      $��Компонент��6$   $��	0,0,195,0q�68   �� 5)      -   5        $ label6��5)      $��Ограничение��6$   $��	83,0,98,0q�6:   �� 5*      -   5        $ label7��5*      $��Колличество��6$   $��	180,0,0,0q�6:   5+      5,   	   �� 5-      -   5        
 ��Name$
 
buttonLeft��5-      $��<��6#   $
��Left=�62   $��	10,0,0,10q�6M   $��69��6`   $��37��6k   $��Bottom=�6w   $��1��6�   $��21.333(�6�   6�   �� 5.      -   5        $
 	buttonAdd��5.      $��+��6"   $
��Left=�6.   $��	84,0,0,10q�6I   $��88��6\   $��37��6g   $��Bottom=�6s   $��1��6�   $��24(�6�   �� 5/      -   5        $
 	buttonDel��5/      $��X��6"   $
��Left=�6.   $��
177,0,0,10q�6I   $��50��6]   $��37��6h   $��Bottom=�6t   $��1��6�   $��16(�6�   6�   �� 50      -   5        $
 buttonRight��50      $��>��6$   $
��Left=�63   $��
232,0,0,10q�6N   $��69��6b   $��37��6m   $��Bottom=�6y   $��1��6�   $��21.333(�6�   6�   51      52      