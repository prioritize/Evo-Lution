using System;
using System.Collections;
using System.Collections.Generic;
// What is a genetic algorithm
// Artificial Intelligience algorithm inspired by evolution
// Population
	// Array of individuals
// Individual (Represented by genes)
	// Array of genes
// Natural Selecetion
	// Fitness function that calculates fit
// Reproduction
	// Crossover
// Mutation
	// Mutation function
public class DNA<T>
{
	public T[] Genes{get; private set;}
	public float Fitness{get; private set;}
	private Random random;
	private Func<T> getRandomGene;

	public DNA(int size, Random random, Func<T>  getRandomGene, bool shouldInitGenes = true)
	{
		Genes = new T[size];
		this.random = random;
		this.getRandomGene = getRandomGene;
		for (int i = 0; i < Genes.Length; i++)
		{
			Genes[i] = getRandomGene();
		}
	}
	public float CalculateFitness()
	{
		return 0;
	}
	public DNA<T> Crossover(DNA<T> otherParent)
	{
		// We know that the output of the crossover function will be a child as this function is simulating reproduction
		DNA<T> child = new DNA<T>(Genes.Length, this.random, getRandomGene);
		// Create a random that will be used to determine which parents genes will be used
		Random random = new Random();
		for (int i = 0; i < Genes.Length; i++)
		{
			
			child.Genes[i] = random.NextDouble() < 0.5f ? Genes[i] : otherParent.Genes[i];
		}
		return child;
	}
	public void Mutate(float mutationRate)
	{
		for (int i = 0; i < Genes.Length; i++)
		{
			if(random.NextDouble() < mutationRate)
			{
				Genes[i] = getRandomGene();
			}
		}
	}

}
