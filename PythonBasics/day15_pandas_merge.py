import pandas as pd 

machines_df = pd.read_csv("machines.csv")
assignments_df = pd.read_csv("assignments.csv")
technicians_df = pd.read_csv("technicians.csv")

merged_df = pd.merge(machines_df, assignments_df, how="left", left_on="name", right_on="machine_name")

#independent
merged2_df = pd.merge(technicians_df,assignments_df, how='left', left_on="FullName", right_on="technician_name")

result = merged2_df.groupby("specialty")["technician_name"].count()

print(merged_df)

unassigned  = merged_df[merged_df["technician_name"].isna()]
print(unassigned)

print(result)