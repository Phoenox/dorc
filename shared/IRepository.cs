﻿using System.Collections.Generic;

namespace Dorc.Shared
{
	public interface IRepository<T>
	{
		public void Update(T obj);
		public T Get(string id);
		public bool Has(string id);
		public List<T> GetAll();
		public void Delete(T obj);
	}
}
