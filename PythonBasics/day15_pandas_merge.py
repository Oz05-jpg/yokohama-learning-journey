import pandas as pd 

machines_df = pd.read_csv("machines.csv")
assignments_df = pd.read_csv("assignments.csv")


merged_df = pd.merge(machines_df, assignments_df, how="left", left_on="name", right_on="machine_name")

print(merged_df)

unassigned  = merged_df[merged_df["technician_name"].isna()]
print(unassigned)