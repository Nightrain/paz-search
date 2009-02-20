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
	/// <summary> Partial implementation of Iteration</summary>
	public abstract class AbstractIteration : Iteration
	{
		/// <summary> Iteration number</summary>
		protected internal int iter;

		public virtual void Reset()
		{
			iter = 0;
		}

		public virtual bool IsFirst
		{
			get { return iter == 0; }
		}

		public virtual void MoveNext()
		{
			iter++;
		}

		public virtual int IterationCount
		{
			get { return iter; }
		}
	}
}