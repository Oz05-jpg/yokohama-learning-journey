import csv

# load technicians from CSV file to list of dicts
def load_technicians_from_csv(filepath):
    technicians_list = []
    with open(filepath, "r", encoding="utf-8") as f:
        reader = csv.DictReader(f)   # TODO: reader แบบไหนให้แต่ละแถวเป็น dict (key = ชื่อ column) — เหมือน Day 3
        for row in reader:
            technicians_list.append({
                "FullName": row["FullName"],
                "job_count": int(row["job_count"])
            })
    return technicians_list


# List comprehension — ชื่อช่างที่ job_count >= threshold
def find_most_job_technicians(technicians_list, threshold=3):
    return [technicians["FullName"]
            for technicians in technicians_list
            if technicians["job_count"] >= threshold]


# Dict comprehension — ชื่อ -> job_count เฉพาะคนที่ job_count >= threshold
def technician_job_lookup(technicians_list, threshold=3):
    return {technicians["FullName"]: technicians["job_count"]
            for technicians in technicians_list
            if technicians["job_count"] >= threshold}


technicians = load_technicians_from_csv("technicians.csv")

names_result = find_most_job_technicians(technicians)
lookup_result = technician_job_lookup(technicians)

print(f"Technicians with job_count >= 3 ({len(names_result)} คน):")
for name in names_result:
    print(f" - {name}")

print("\nLookup (name -> job_count):")
print(lookup_result)
