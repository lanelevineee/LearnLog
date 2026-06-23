'use client';

import { useEffect, useState } from 'react';

interface Appointment {
  id: string;
  patientId: string;
  doctorId: string;
  startTime: string;
  status: string;
}

export default function AppointmentsPage() {
  const [appointments, setAppointments] = useState<Appointment[]>([]);

  useEffect(() => {
    fetch('/api/appointments')
      .then(res => res.json())
      .then(data => setAppointments(data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div className="p-8">
      <h1 className="text-2xl font-bold mb-6">Appointments</h1>
      <div className="grid gap-4">
        {appointments.map(appt => (
          <div key={appt.id} className="p-4 border rounded shadow-sm flex justify-between items-center">
            <div>
              <p className="font-semibold">Patient: {appt.patientId}</p>
              <p className="text-sm text-gray-500">{new Date(appt.startTime).toLocaleString()}</p>
            </div>
            <span className="px-2 py-1 rounded text-xs bg-blue-100 text-blue-800">
              {appt.status}
            </span>
          </div>
        ))}
      </div>
    </div>
  );
}
