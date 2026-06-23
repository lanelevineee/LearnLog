'use client';

import { useEffect, useState } from 'react';

interface Tenant {
  id: string;
  name: string;
  hostname: string;
  isActive: boolean;
}

export default function TenantsPage() {
  const [tenants, setTenants] = useState<Tenant[]>([]);

  useEffect(() => {
    fetch('/api/superadmin/tenants')
      .then(res => res.json())
      .then(data => setTenants(data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div className="p-8">
      <h1 className="text-2xl font-bold mb-6">Health Organizations (Tenants)</h1>
      <div className="grid gap-4">
        {tenants.map(tenant => (
          <div key={tenant.id} className="p-4 border rounded shadow-sm flex justify-between items-center">
            <div>
              <p className="font-semibold">{tenant.name}</p>
              <p className="text-sm text-gray-500">{tenant.hostname}</p>
            </div>
            <span className={`px-2 py-1 rounded text-xs ${tenant.isActive ? 'bg-green-100 text-green-800' : 'bg-red-100 text-red-800'}`}>
              {tenant.isActive ? 'Active' : 'Inactive'}
            </span>
          </div>
        ))}
      </div>
    </div>
  );
}
