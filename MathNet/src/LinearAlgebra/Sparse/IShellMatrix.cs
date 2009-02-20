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

namespace MathNet.Numerics.LinearAlgebra.Sparse
{
	/// <summary> Matrix with external storage and custom matrix/vector product.</summary>
	public interface IShellMatrix : IMatrix
	{
		/// <summary> <c>z = alpha*A*x + beta*y</c>. x can not be the same as y or z.</summary>
		/// <returns> z </returns>
		IVector MultAdd(double alpha, IVector x, double beta, IVector y, IVector z);

		/// <summary>
		/// <c>z = alpha*A<sup>T</sup>*x + beta*y</c>. x can not be the same as y or z.
		/// </summary>
		/// <returns> z </returns>
		IVector TransMultAdd(double alpha, IVector x, double beta, IVector y, IVector z);
	}
}