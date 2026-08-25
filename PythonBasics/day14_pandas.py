import pandas as pd

df = pd.read_csv("technicians.csv")

average = df["job_count"].mean()
overloaded = df[df["job_count"] > average]

avg_by_specialty = df.groupby("specialty")["job_count"].mean()
print(df.head())
# print(df["job_count"].mean())

print(avg_by_specialty)
print(df.sort_values("job_count", ascending = False))

# print("---ช่างที่ทำงานเกินค่าเฉลี่ย---")
# print(overloaded)