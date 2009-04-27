#region Copyright �2004 Joannes Vermorel

// MathNet Numerics, part of MathNet
//
// Copyright (c) 2004,	Joannes Vermorel, http://www.vermorel.com
// Based on JMP , Copyright (c) 2003 Bj�rn-Ove Heimsund
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published 
// by the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public 
// License along with this program; if not, write to the Free Software
// Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.

#endregion

using MathNet.Numerics.LinearAlgebra.Sparse;

namespace MathNet.Numerics.LinearAlgebra.Sparse.Eigenvalue
{
	/// <summary> Partial implementation of EigenvalueTransformation</summary>
	public abstract class AbstractEigenvalueTransformation : IEigenvalueTransformation
	{
		/// <summary> Constructor for AbstractEigenvalueTransformation</summary>
		public AbstractEigenvalueTransformation()
		{
		}

		public virtual double[] Eigenvalue(double[] e)
		{
			for (int i = 0; i < e.Length; ++i) e[i] = Eigenvalue(e[i]);
			return e;
		}

		public abstract double Eigenvalue(double param1);
		public abstract IVector Apply(IMatrix param1, IVector param2, IVector param3);

		public abstract double Shift { get; set; }
	}
}