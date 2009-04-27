#region MathNet Numerics, Copyright �2004 Joannes Vermorel

// MathNet Numerics, part of MathNet
//
// Copyright (c) 2004,	Joannes Vermorel, http://www.vermorel.com
//
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

using System;

using MathNet.Numerics;

namespace MathNet.Numerics.Generators
{
	// TODO: testing suite for NormalGenerator

	/// <summary>
	/// Pseudo-random generator of normally distributed deviates.
	/// </summary>
	/// <remarks>
	/// <p>This implementation is based on the <i>Box-Muller</i> algorithm
	/// for generating random deviates with a normal distribution.</p>
	/// 
	/// <p>See the <a href="http://en.wikipedia.org/wiki/Normal_distribution">
	/// WikiPedia</a> for detail about the normal distribution.</p>
	/// <p>See <a href="http://www.library.cornell.edu/nr/">Numerical recipees in C</a> 
	/// (chapter 7) for the detail of the algorithm.</p>
	/// </remarks>
	public class NormalGenerator : IRealGenerator
	{
		private static Random random = new Random();

		private double mean;
		private double sigma;

		/// <summary>Extra normal deviate generated by a call to 
		/// <c>NormalGenenator.Next()</c>.</summary>
		/// <seealso cref="Next"/>
		private double extraNormal = double.NaN;

		/// <summary>Standard normal generator.</summary>
		/// <remarks>The normal distribution has a zero mean and
		/// standart deviation equal to one.</remarks>
		public NormalGenerator()
		{
			this.mean = 0d;
			this.sigma = 1d;
		}

		/// <summary>Normal generator.</summary>
		/// <param name="mean">Mean.</param>
		/// <param name="sigma">Standard deviation.</param>
		public NormalGenerator(double mean, double sigma)
		{
			this.mean = mean;
			this.sigma = sigma;
		}

		/// <summary>Gets or sets the mean of the normal distribution.</summary>
		public double Mean
		{
			get { return mean; }
			set { mean = value; }
		}

		/// <summary>Gets or sets the standard deviation of
		/// the normal distribution.</summary>
		public double Sigma
		{
			get { return sigma; }
			set { sigma = value; }
		}

		private double NextStandard()
		{
			// Note that this method generate two gaussian deviates
			// at once. The additional deviate is recorded in
			// <c>Random.extraNormal</c>.
	
			// Using the extra gaussian deviate if available
			if(!extraNormal.Equals(double.NaN))
			{
				double extraNormalCpy = extraNormal;
				extraNormal = double.NaN;
				return extraNormalCpy;
			}
				// Generating two new gaussian deviates
			else
			{
				double fac, rsq, v1, v2;

				// We need a non-zero random point inside the unit circle.
				do
				{
					v1 = 2.0 * random.NextDouble() - 1.0;
					v2 = 2.0 * random.NextDouble() - 1.0;
					rsq = v1*v1 + v2*v2;
				} 
				while(rsq > 1.0 || rsq == 0);

				// Make the Box-Muller transformation
				fac = Math.Sqrt(-2.0 * Math.Log(rsq) / rsq);

				extraNormal = v1 * fac;
				return (v2 * fac);
			}
		}

		/// <summary>Returns the next pseudo random normally distributed deviate.</summary>
		public double Next()
		{
			return mean + this.NextStandard() * sigma;
		}
	}
}
