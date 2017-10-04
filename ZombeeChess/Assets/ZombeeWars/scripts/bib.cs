using UnityEngine;
using System.Collections;
// содержит все цифры и переменные которыми будем оперировать
public class bib : MonoBehaviour
{
	#region UnitState UTag UClases
	public enum UTag{White,Black,isNeutral};
	public enum UStates {wait,moove,attack1,attack2,dead,patient};
	public enum UTyp {Tank,DD,RangeDD};
	public enum UClases{Hiller,Solider,Sniper,Tank,Ninzya, Rider};
    #endregion


    #region unitsParameters

	public static int HPTank = 100;
	public static int HPDD=75;
	public static int HPRanger=50;

	public static float speed=5.0f;



    #endregion


}
/* create driving for round
 * create universal eventloking
 * 
 * */