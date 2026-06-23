'use client';

import { useEffect, useState } from 'react';

interface Patient {
  id: string;
  firstName: string;
  lastName: string;
  gender: string;
}

export default function PatientsPage() {
  const [patients, setPatients] = useState<Patient[]>([]);

  useEffect(() => {
    fetch('/api/patients')
      .then(res => res.json())
      .then(data => setPatients(data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div className="p-8">
      <h1 className="text-2xl font-bold mb-6">Patients</h1>
      <div className="grid gap-4">
        {patients.map(patient => (
          <div key={patient.id} className="p-4 border rounded shadow-sm">
            <p className="font-semibold">{patient.firstName} {patient.lastName}</p>
            <p className="text-sm text-gray-500">{patient.gender}</p>
          </div>
        ))}
      </div>
    </div>
  );
}
