import csv
import numpy as np

with open("technicians.csv", "r", encoding="utf-8") as f:
    reader = csv.DictReader(f)
    name_list = []
    job_counts_list = []
    for row in reader:
        name_list.append(row["FullName"])
        job_counts_list.append(int(row["job_count"]))

technician_names = np.array(name_list)
job_counts = np.array(job_counts_list)

average = job_counts.mean()
overloaded_names = technician_names[job_counts > average]

print("เฉลี่ย:", average)
print("Technician ที่งานเกินเฉลี่ย:")
for name in overloaded_names:
    print("-", name)
