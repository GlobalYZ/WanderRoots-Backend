import pandas as pd
from datasets import load_dataset

def fetch_and_convert_to_csv():
    try:
        # load dataset from Hugging Face
        dataset = load_dataset("Falah/countries_jokes_dataset", split="train")
        
        # convert dataset to pandas DataFrame
        df = pd.DataFrame(dataset)
        
        # save to csv file
        output_file = "jokes.csv"
        df.to_csv(output_file, index=False)
        print(f"data saved to {output_file}")
        
    except Exception as e:
        print(f"error: {str(e)}")

if __name__ == "__main__":
    fetch_and_convert_to_csv() 