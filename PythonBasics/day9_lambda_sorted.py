import csv


def load_technicians_from_csv(filepath):
    technicians_list = []
    with open(filepath, "r", encoding="utf-8") as f:
        reader = csv.DictReader(f)
        for row in reader:
            technicians_list.append({
                "FullName": row["FullName"],
                "job_count": int(row["job_count"])
            })
    return technicians_list


def sorted_by_job_count(technicians_list, descending=False):
    return sorted(technicians_list, key=lambda x: x["job_count"], reverse=descending)


technicians = load_technicians_from_csv("technicians.csv")

ascending_result = sorted_by_job_count(technicians)
descending_result = sorted_by_job_count(technicians, descending=True)

print("Technicians sorted by job_count (ascending):")
for t in ascending_result:
    print(f" - {t['FullName']}: {t['job_count']}")

print("\nTechnicians sorted by job_count (descending):")
for t in descending_result:
    print(f" - {t['FullName']}: {t['job_count']}")
